namespace DatabaseLocalizationSample.DataAccessLayer.Entities;

public class LandmarkTranslation
{
    public Guid Id { get; set; }

    public Guid LandmarkId { get; set; }

    public string Language { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual Landmark Landmark { get; set; }
}
