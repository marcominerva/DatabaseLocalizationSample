using DatabaseLocalizationSample.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLocalizationSample.DataAccessLayer.Configurations;

public class LandmarkConfiguration : IEntityTypeConfiguration<Landmark>
{
    public void Configure(EntityTypeBuilder<Landmark> builder)
    {
        builder.ToTable("Landmarks");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
        builder.Property(e => e.ImageUrl).HasMaxLength(1024);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
    }
}
