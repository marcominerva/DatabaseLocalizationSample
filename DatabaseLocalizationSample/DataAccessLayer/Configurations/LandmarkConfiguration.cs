using DatabaseLocalizationSample.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLocalizationSample.DataAccessLayer.Configurations;

public class LandmarkConfiguration : IEntityTypeConfiguration<Landmark>
{
    public void Configure(EntityTypeBuilder<Landmark> builder)
    {
        _ = builder.ToTable("Landmarks");
        _ = builder.HasKey(e => e.Id);

        _ = builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
        _ = builder.Property(e => e.ImageUrl).HasMaxLength(1024);
        _ = builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
    }
}
