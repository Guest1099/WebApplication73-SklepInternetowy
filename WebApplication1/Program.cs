using Application;
using Application.Services;
using Application.Services.Abs;
using Data;
using Data.Repos;
using Data.Repos.Abs;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 10;

    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddRoles<ApplicationRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(o =>
{
    // zabezpieczenia token w mailowych wysy anych do potwierdzenia konta
    o.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    o.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
});

/*services.AddAuthentication("AdminScheme")
    .AddCookie("AdminScheme", options =>
    {
        options.LoginPath = "/Admin/Account/Login";
        options.AccessDeniedPath = "/Admin/Account/Login";
    });

services.AddAuthentication ("DefaultScheme")
    .AddCookie("DefaultScheme", options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";
    });*/

builder.Services.AddAuthorization();

builder.Services.ConfigureApplicationCookie(cookie =>
{
    cookie.LoginPath = "/Account/Login";
    //cookie.LogoutPath = "/Home/Index"; 
    cookie.AccessDeniedPath = "/Account/Login";
    cookie.Cookie.HttpOnly = true; // uniemo liwia dost p do ciasteczek z poziomu skrypt w JavaScript
});

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();


// wysy anie token w potwierdzaj cych na maila
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});
// Konfiguracja okresu wa no ci tokena dla DataProtectorTokenProvider
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(30);
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IColorsProductRepository, ColorsProductRepository>();
builder.Services.AddScoped<IColorsRepository, ColorsRepository>();
builder.Services.AddScoped<IFavouritesRepository, FavouritesRepository>();
builder.Services.AddScoped<IMarkiRepository, MarkiRepository>();
builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();
//builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<IPhotosProductRepository, PhotosProductRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
//builder.Services.AddScoped<IReceiveMessagesRepository, ReceiveMessagesRepository>();
//builder.Services.AddScoped<ISendMessagesRepository, SendMessagesRepositorsy>();
builder.Services.AddScoped<ISizesProductRepository, SizesProductRepository>();
builder.Services.AddScoped<ISubcategoriesRepository, SubcategoriesRepository>();
builder.Services.AddScoped<ISubsubcategoriesRepository, SubsubcategoriesRepository>();


builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IColorsProductService, ColorsProductService>();
builder.Services.AddScoped<IColorsService, ColorsService>();
builder.Services.AddScoped<IFavouritesService, FavouritesService>();
builder.Services.AddScoped<IMarkiService, MarkiService>();
builder.Services.AddScoped<INewsletterService, NewsletterService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ISizesProductService, SizesProductService>();
builder.Services.AddScoped<ISizesService, SizesService>();
builder.Services.AddScoped<ISubcategoriesService, SubcategoriesService>();
builder.Services.AddScoped<ISubsubcategoriesService, SubsubcategoriesService>();

builder.Services.AddScoped<ReceiveMessagesService>();
builder.Services.AddScoped<SendMessagesService>();


builder.Services.AddScoped(typeof(UsersService));
builder.Services.AddTransient(typeof(HtmlSanitizationService));
builder.Services.AddTransient(typeof(KoszykService));
builder.Services.AddTransient(typeof(TempOrderService));

builder.Services.AddScoped<IEmailSender, EmailSender>();



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

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
