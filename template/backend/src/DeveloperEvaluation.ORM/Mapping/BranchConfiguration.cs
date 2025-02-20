using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DeveloperEvaluation.ORM.Mapping
{

    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {

            builder.ToTable("Branch");


            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()");


            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(f => f.Address)
                .IsRequired()
                .HasMaxLength(255);

        }
    }

}
