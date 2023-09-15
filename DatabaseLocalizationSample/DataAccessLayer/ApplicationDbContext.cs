using System.Reflection;
using DatabaseLocalizationSample.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLocalizationSample.DataAccessLayer;

public class ApplicationDbContext : DbContext
{
    public DbSet<Landmark> Landmarks { get; set; }

    public DbSet<LandmarkTranslation> LandmarkTranslations { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    //    => configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
}
