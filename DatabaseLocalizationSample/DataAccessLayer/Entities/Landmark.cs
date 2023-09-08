namespace DatabaseLocalizationSample.DataAccessLayer.Entities;

public class Landmark
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public virtual ICollection<LandmarkTranslation> Translations { get; set; } = new List<LandmarkTranslation>();
}
