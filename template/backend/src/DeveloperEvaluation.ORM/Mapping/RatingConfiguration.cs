﻿using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeveloperEvaluation.ORM.Mapping
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");

            builder.HasKey(a => a.Id);
            builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

            builder.Property(a => a.Rate)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Count)
                .IsRequired();

        }
    }
}
