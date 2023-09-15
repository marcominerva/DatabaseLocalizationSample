using DatabaseLocalizationSample.DataAccessLayer;
using DatabaseLocalizationSample.Models;
using DatabaseLocalizationSample.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TinyHelpers.AspNetCore.Extensions;
using TinyHelpers.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();

builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration.GetConnectionString("SqlConnection"),
    options =>
    {
        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    });

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
//        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
//});

builder.Services.AddScoped<ILandmarkService, LandmarkService>();

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

app.MapGet("/api/landmarks", async (string name, ILandmarkService landmarkService) =>
{
    var landmarks = await landmarkService.GetAsync(name);
    return TypedResults.Ok(landmarks);
})
.WithName("GetLandmarks")
.WithOpenApi();

app.MapGet("/api/landmarks/{id:guid}", async Task<Results<Ok<Landmark>, NotFound>> (HttpContext context, Guid id, ILandmarkService landmarkService) =>
{
    var landmark = await landmarkService.GetAsync(id);
    if (landmark is null)
    {
        return TypedResults.NotFound();
    }

    return TypedResults.Ok(landmark);
})
.WithName("GetLandmark")
.WithOpenApi();

app.MapGet("/api/landmarks/names", async (ILandmarkService landmarkService) =>
{
    var landmarks = await landmarkService.GetNamesAsync();
    return TypedResults.Ok(landmarks);
})
.WithName("GetLandmarkNames")
.WithOpenApi();

app.MapPut("/api/landmarks", async (Landmark landmark, ILandmarkService landmarkService) =>
{
    await landmarkService.UpdateAsync(landmark);
    return TypedResults.NoContent();
})
.WithName("UpdateLandmark")
.WithOpenApi();

app.Run();
