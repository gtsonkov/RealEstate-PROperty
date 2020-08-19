using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstates.Models;

namespace RealEstates.Data.EntityConfiguration
{
    internal class RealEstateTagConfiguration : IEntityTypeConfiguration<RealEstateTag>
    {
        public void Configure(EntityTypeBuilder<RealEstateTag> builder)
        {
            builder.HasKey(pk => new { pk.RealEstateId, pk.TagId });

            builder.HasOne(re => re.RealEstate)
                .WithMany(ret => ret.Tags)
                .HasForeignKey(re => re.RealEstateId);

            builder.HasOne(t => t.Tag)
                .WithMany(tre => tre.RealEstateProperties)
                .HasForeignKey(t => t.TagId);
        }
    }
}