using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SNGG.DataAccess;
using SNGG.Services;
using SNGG.Web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "SNGG APIs", Version = "v1" });
});

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ICheckGuessService, CheckGuessService>();
builder.Services.AddSingleton<ICalculateService, CalculateService>();

var connectionstring = "Server=SUBTOPHANS\\TT;Database=SNGGDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;Connection Timeout=4800;Application Name=SNGGHans;";
builder.Services.AddDbContextFactory<SNGGContext>(options =>
            options.UseSqlServer(connectionstring,
              options => options.MinBatchSize(1).CommandTimeout(3600).MaxBatchSize(200).EnableRetryOnFailure(3)), ServiceLifetime.Singleton);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();
app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//app.ConfigureEndpoints();

app.Run();
