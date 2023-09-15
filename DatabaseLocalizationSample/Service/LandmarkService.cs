using DatabaseLocalizationSample.DataAccessLayer;
using DatabaseLocalizationSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TinyHelpers.Extensions;

namespace DatabaseLocalizationSample.Service;

public class LandmarkService : ILandmarkService
{
    private readonly ApplicationDbContext dbContext;
    private readonly IMemoryCache cache;

    public LandmarkService(ApplicationDbContext dbContext, IMemoryCache cache)
    {
        this.dbContext = dbContext;
        this.cache = cache;
    }

    public async Task<IEnumerable<Landmark>> GetAsync(string name)
    {
        var language = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        var dbLandmarks = await dbContext.Landmarks
            .Include(l => l.Translations.Where(t => t.Language == language))
            .WhereIf(name.HasValue(),
                l => l.Translations.Any(t => t.Language == language && t.Name.Contains(name))
                || l.Name.Contains(name))
            .ToListAsync();

        var landmarks = dbLandmarks.Select(l => new Landmark
        {
            Id = l.Id,
            ImageUrl = l.ImageUrl,
            Name = l.Translations.FirstOrDefault()?.Name ?? l.Name,
            Description = l.Translations.FirstOrDefault()?.Description ?? l.Description
        });

        return landmarks;
    }

    public async Task<IEnumerable<string>> GetNamesAsync()
    {
        var landmarks = cache.Get<List<string>>("landmarks");

        if (landmarks is null)
        {
            landmarks = await dbContext.Landmarks
               .OrderBy(l => l.Name).Select(l => l.Name).ToListAsync();

            cache.Set("landmarks", landmarks);
        }

        var names = landmarks.ToList();
        names.Insert(0, "-");

        return names;
    }

    public Task<Landmark> GetAsync(Guid id)
    {
        var dbLandmark = dbContext.Landmarks.FirstOrDefault(l => l.Id == id);
        if (dbLandmark is null)
        {
            return Task.FromResult<Landmark>(null);
        }

        var landmark = new Landmark
        {
            Id = dbLandmark.Id,
            ImageUrl = dbLandmark.ImageUrl,
            Name = dbLandmark.Name,
            Description = dbLandmark.Description
        };

        return Task.FromResult(landmark);
    }

    public async Task UpdateAsync(Landmark landmark)
    {
        var dbLandmark = await dbContext.Landmarks.AsTracking()
            .FirstOrDefaultAsync(l => l.Id == landmark.Id);

        if (dbLandmark is not null)
        {
            dbLandmark.Name = landmark.Name;
            dbLandmark.Description = landmark.Description;
            dbLandmark.ImageUrl = landmark.ImageUrl;

            await dbContext.SaveChangesAsync();
        }
    }
}
