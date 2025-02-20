﻿using DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DeveloperEvaluation.ORM.Mapping
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            
            builder.HasKey(a => a.Id);

            
            builder.Property(a => a.Id)
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("gen_random_uuid()");

            
            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Zipcode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(a => a.Number)
                   .IsRequired();

            builder.Property(a => a.GeolocationId)
                   .IsRequired();

            builder.HasOne(a => a.Geolocation) 
                   .WithOne()  
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
