using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_Do_Flip.DataAccess.Entity;
using To_Do_Flip.Store.Model;

namespace To_Do_Flip.DataAccess.Configuration;

public class To_Do_Flip_Configuration : IEntityTypeConfiguration<To_Do_Flip_Entity>
{
    public void Configure(EntityTypeBuilder<To_Do_Flip_Entity> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(t => t.Name)
            .HasMaxLength(To_Do.MAX_LENGTH)
            .IsRequired();
        
        builder.Property(t => t.Description)
            .HasMaxLength(To_Do.MAX_LENGTH)
            .IsRequired();
    }
}