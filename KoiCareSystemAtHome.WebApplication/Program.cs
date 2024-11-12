using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Repositories.Reponsitories;
using KoiCareSystemAtHome.Repositories.Repositories;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// DI
builder.Services.AddDbContext<KoiCareSystemAtHomeContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});
// DI Repository
builder.Services.AddScoped<IWaterParameterRepository, WaterParameterRepository>();
builder.Services.AddScoped<IPondRepository, PondRepository>();
builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFeedingScheduleRepository, FeedingScheduleRepository>();
builder.Services.AddScoped<ISaltCalculationRepository, SaltCalculationRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// DI Services
builder.Services.AddScoped<IFeedingScheduleService, FeedingScheduleService>();
builder.Services.AddScoped<ISaltCalculationService, SaltCalculationService>();
builder.Services.AddScoped<IWaterParameterService, WaterParameterService>();
builder.Services.AddScoped<IPondService, PondService>();
builder.Services.AddScoped<IKoiFishService, KoiFishService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();



// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();