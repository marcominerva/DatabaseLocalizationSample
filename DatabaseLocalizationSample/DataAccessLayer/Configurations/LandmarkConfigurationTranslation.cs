using DatabaseLocalizationSample.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLocalizationSample.DataAccessLayer.Configurations;

public class LandmarkConfigurationTranslation : IEntityTypeConfiguration<LandmarkTranslation>
{
    public void Configure(EntityTypeBuilder<LandmarkTranslation> builder)
    {
        builder.ToTable("LandmarkTranslations");
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.LandmarkId, e.Language }, "IX_LandmarkTranslations");

        builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
        builder.Property(e => e.Language).IsRequired().HasMaxLength(2).IsUnicode(false).IsFixedLength();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);

        builder.HasOne(d => d.Landmark).WithMany(p => p.Translations)
           .HasForeignKey(d => d.LandmarkId)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("FK_LandmarkTranslations_Landmarks");
    }
}
