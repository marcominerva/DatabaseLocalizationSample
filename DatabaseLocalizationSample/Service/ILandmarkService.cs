using DatabaseLocalizationSample.Models;

namespace DatabaseLocalizationSample.Service;

public interface ILandmarkService
{
    Task<IEnumerable<Landmark>> GetAsync(string name);

    Task<Landmark> GetAsync(Guid id);

    Task UpdateAsync(Landmark landmark);

    Task<IEnumerable<string>> GetNamesAsync();
}