using Microsoft.EntityFrameworkCore;
using To_Do_Flip.Application.Repository;
using To_Do_Flip.Application.Service;
using To_Do_Flip.DataAccess.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Render (и некоторые PaaS) задают порт через переменную окружения PORT.
// Если PORT задан — слушаем его. Иначе остаёмся на дефолте (задается launchSettings / ASPNETCORE_URLS).
var portEnv = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(portEnv) && int.TryParse(portEnv, out var port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// Render часто отдаёт строку подключения как URL вида: postgres://user:pass@host:port/db
// EF Core + Npgsql ожидает keyword connection string: Host=...;Port=...;Database=...;Username=...;Password=...
var rawConn = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrWhiteSpace(rawConn) &&
    (rawConn.StartsWith("postgres://", StringComparison.OrdinalIgnoreCase) ||
     rawConn.StartsWith("postgresql://", StringComparison.OrdinalIgnoreCase)))
{
    var uri = new Uri(rawConn);
    var userInfo = uri.UserInfo.Split(':', 2);
    var username = userInfo.Length > 0 ? Uri.UnescapeDataString(userInfo[0]) : "";
    var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : "";
    var database = uri.AbsolutePath.TrimStart('/');

    var normalized =
        $"Host={uri.Host};Port={uri.Port};Database={database};Username={username};Password={password};Ssl Mode=Require;Trust Server Certificate=true";

    builder.Configuration["ConnectionStrings:DefaultConnection"] = normalized;
}

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<To_Do_Flip_Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory", "public")));

builder.Services.AddScoped<To_Do_Flip_IRepository, To_Do_Flip_Repository>();
builder.Services.AddScoped<To_Do_Flip_IService, To_Do_Flip_Service>();

var app = builder.Build();

// Применяем миграции при запуске (для Docker)
// В режиме Development миграции применяются вручную через dotnet ef
var environment = app.Environment.EnvironmentName;
if (environment == "Production" || environment == "Docker")
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<To_Do_Flip_Context>();
            context.Database.Migrate();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Произошла ошибка при применении миграций базы данных");
            // В Production/Docker не продолжаем работу без БД
            if (environment == "Production")
            {
                throw;
            }
        }
    }
}

app.UseCors();
app.MapControllers();
app.Run();