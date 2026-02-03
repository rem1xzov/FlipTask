# Используем официальный образ .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем файлы проектов
COPY ["To-Do_Flip/To-Do_Flip.csproj", "To-Do_Flip/"]
COPY ["To-Do_Flip.Application/To-Do_Flip.Application.csproj", "To-Do_Flip.Application/"]
COPY ["To-Do_Flip.DataAccess/To-Do_Flip.DataAccess.csproj", "To-Do_Flip.DataAccess/"]
COPY ["To-Do_Flip.Store/To-Do_Flip.Store.csproj", "To-Do_Flip.Store/"]

# Восстанавливаем зависимости
RUN dotnet restore "To-Do_Flip/To-Do_Flip.csproj"

# Копируем весь код
COPY . .

# Собираем приложение
WORKDIR "/src/To-Do_Flip"
RUN dotnet build "To-Do_Flip.csproj" -c Release -o /app/build

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "To-Do_Flip.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# Копируем опубликованное приложение
COPY --from=publish /app/publish .

# Устанавливаем инструменты EF Core для применения миграций
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*

ENTRYPOINT ["dotnet", "To-Do_Flip.dll"]
