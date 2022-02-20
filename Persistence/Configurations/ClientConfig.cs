using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients")
            .HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(p => p.FamilyName)
            .HasMaxLength(80)
            .IsRequired();
                
        builder.Property(p => p.DateOfBirth)
            .IsRequired();
        
        builder.Property(p => p.Phone)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(p => p.Email)
            .HasMaxLength(100);

        builder.Property(p => p.Address)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Age);
        
        builder.Property(p => p.CreatedBy)
            .HasMaxLength(30);
        
        builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(30);
    }
}