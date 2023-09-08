using DatabaseLocalizationSample.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatabaseLocalizationSample.DataAccessLayer.Configurations;

public class LandmarkConfigurationTranslation : IEntityTypeConfiguration<LandmarkTranslation>
{
    public void Configure(EntityTypeBuilder<LandmarkTranslation> builder)
    {
        _ = builder.ToTable("LandmarkTranslations");
        _ = builder.HasKey(e => e.Id);

        _ = builder.HasIndex(e => new { e.LandmarkId, e.Language }, "IX_LandmarkTranslations");

        _ = builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
        _ = builder.Property(e => e.Language)
            .IsRequired()
            .HasMaxLength(2)
            .IsUnicode(false)
            .IsFixedLength();
        _ = builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(255);

        _ = builder.HasOne(d => d.Landmark).WithMany(p => p.Translations)
            .HasForeignKey(d => d.LandmarkId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_LandmarkTranslations_Landmarks");
    }
}
