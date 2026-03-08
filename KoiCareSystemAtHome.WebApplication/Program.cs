using KoiCareSystemAtHome.Repositories;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using KoiCareSystemAtHome.Repositories.Reponsitories;
using KoiCareSystemAtHome.Repositories.Repositories;
using KoiCareSystemAtHome.Services.Interfaces;
using KoiCareSystemAtHome.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình Database
builder.Services.AddDbContext<KoiCareSystemAtHomeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
});

// DI Repositories
builder.Services.AddScoped<IWaterParameterRepository, WaterParameterRepository>();
builder.Services.AddScoped<IPondRepository, PondRepository>();
builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFeedingScheduleRepository, FeedingScheduleRepository>();
builder.Services.AddScoped<ISaltCalculationRepository, SaltCalculationRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

// DI Services
builder.Services.AddScoped<IFeedingScheduleService, FeedingScheduleService>();
builder.Services.AddScoped<ISaltCalculationService, SaltCalculationService>();
builder.Services.AddScoped<IWaterParameterService, WaterParameterService>();
builder.Services.AddScoped<IPondService, PondService>();
builder.Services.AddScoped<IKoiFishService, KoiFishService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

// Cấu hình AUTHENTICATION
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/LoginPage";
        options.AccessDeniedPath = "/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

// Cấu hình SESSION
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Cấu hình Razor Pages & Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/AccountPage", "AdminOnly");
    options.Conventions.AuthorizeFolder("/UserPage", "AdminOnly");
    options.Conventions.AuthorizeFolder("/PondPage");
    options.Conventions.AuthorizeFolder("/FeedingSchedulePages");
    options.Conventions.AuthorizeFolder("/KoiFishPage");
    options.Conventions.AuthorizeFolder("/NewsPage");
    options.Conventions.AuthorizeFolder("/ProductPage");
    options.Conventions.AuthorizeFolder("/Shared");
    options.Conventions.AuthorizeFolder("/SaltCalculationPages");
    options.Conventions.AuthorizeFolder("/WaterParameterPages");
    options.Conventions.AuthorizePage("/DashBoard");
});

var app = builder.Build();

// --- Cấu hình HTTP Request Pipeline ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();