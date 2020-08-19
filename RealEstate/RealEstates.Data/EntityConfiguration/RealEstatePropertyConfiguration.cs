using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.EntityConfiguration
{
    internal class RealEstatePropertyConfiguration : IEntityTypeConfiguration<RealEstateProperty>
    {
        public void Configure(EntityTypeBuilder<RealEstateProperty> builder)
        {
            builder.HasOne(p => p.BuildingType)
                .WithMany(bt => bt.Properties)
                .HasForeignKey(p => p.BuildingTypeId);

            builder.HasOne(p => p.PropertyType)
                .WithMany(pt => pt.Properties)
                .HasForeignKey(p => p.PropertyTypeId);
        }
    }
}