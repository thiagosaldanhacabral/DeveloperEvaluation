using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.ORM.Mapping
{

    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.ToTable("SaleProduct");

            builder.HasKey(vp => new { vp.SaleId, vp.ProductId });

            builder.Property(vp => vp.SaleId)
                .HasColumnType("uuid");

            builder.Property(vp => vp.Product)
                .HasColumnType("uuid");

            builder.HasOne(vp => vp.Sale)
                .WithMany(v => v.SaleProducts)
                .HasForeignKey(vp => vp.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(vp => vp.Product)
                .WithMany()
                .HasForeignKey(vp => vp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(vp => vp.Quantity)
                .IsRequired();

            builder.Property(vp => vp.UnitPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(vp => vp.Discount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(vp => vp.TotalValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }

}
