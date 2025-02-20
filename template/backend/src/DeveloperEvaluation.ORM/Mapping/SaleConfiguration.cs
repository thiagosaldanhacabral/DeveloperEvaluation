using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.ORM.Mapping
{
   
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {

            builder.ToTable("Sale");

            
            builder.HasKey(v => v.Id);

            
            builder.Property(v => v.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");

            
            builder.Property(v => v.SaleDate)
                .IsRequired();

            builder.Property(v => v.TotalValue)
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.Canceled)
                .IsRequired();

            
            builder.HasOne(v => v.Customer)  
                .WithMany()  
                .HasForeignKey(v => v.CustomerId)  
                .OnDelete(DeleteBehavior.Restrict);  
            
            builder.HasMany(v => v.SaleProducts) 
                .WithOne()  
                .HasForeignKey(vp => vp.SaleId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }

}
