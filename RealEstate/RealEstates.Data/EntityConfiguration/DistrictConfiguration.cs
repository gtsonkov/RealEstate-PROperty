using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.EntityConfiguration
{
    internal class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasMany(d => d.Properties)
                .WithOne(p => p.District)
                .HasForeignKey(p => p.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}