using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Services;
using KoiCareSystemAtHome.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<KoiCareSystemAtHomeContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});
//DI Repository
builder.Services.AddScoped<IPondRepository, PondRepository>();
//DI Service
builder.Services.AddScoped<IPondService, PondService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    IApplicationBuilder applicationBuilder = app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
