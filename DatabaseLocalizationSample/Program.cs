using DatabaseLocalizationSample.DataAccessLayer;
using DatabaseLocalizationSample.Models;
using Microsoft.EntityFrameworkCore;
using TinyHelpers.AspNetCore.Extensions;
using TinyHelpers.AspNetCore.Swagger;
using TinyHelpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("SqlConnection"));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    _ = options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddRequestLocalization("it", "en", "de");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddAcceptLanguageHeader();
});

var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseRequestLocalization();

app.MapGet("/api/landmarks", async (string name, ApplicationDbContext dbContext) =>
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

    return TypedResults.Ok(landmarks);
})
.WithName("GetLandmarks")
.WithOpenApi();

app.Run();
