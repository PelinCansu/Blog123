using Blog123.Application.Services.AppRoleService;
using Blog123.Application.Services.AppUserService;
using Blog123.Application.Services.AuthorService;
using Blog123.Application.Services.CategoryServices;
using Blog123.Application.Services.PostService;
using Blog123.Domain.Entities.Concrete;
using Blog123.Domain.Repositories;
using Blog123.Infrastructure.ConcreteRepositories;
using Blog123.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Blog123DbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedPhoneNumber = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    
}).AddEntityFrameworkStores<Blog123DbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(120);

    options.LoginPath = "/Account/Login";
    //options.AccessDeniedPath = "//Account/AccessDenied";
    options.SlidingExpiration = true;
});

//.Net Core çekirdeði IoC prensibi ile çalýþýr. Bu yüzden AspNet Core Mvc için hazýrlanan IoC containerlarýna hangi talepte hangi nesnenin resolve edileceðini veriyoruz.
builder.Services.AddTransient<IAppUserService, AppUserService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IAppRoleService, AppRoleService>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ICategoryPostRepository, CategoryPostRepository>();

//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseCookiePolicy();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
