using Microsoft.EntityFrameworkCore;
using To_Do_Flip.DataAccess.Entity;
using To_Do_Flip.DataAccess.Configuration;

namespace To_Do_Flip.DataAccess.DbContext;

public class To_Do_Flip_Context : Microsoft.EntityFrameworkCore.DbContext
{
    public To_Do_Flip_Context(DbContextOptions<To_Do_Flip_Context> options) : base(options) { }
    
    public DbSet<To_Do_Flip_Entity> To_Do_Flip_Entities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new To_Do_Flip_Configuration());
    }
}