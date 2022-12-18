using Cheapla.Business.Managers;
using Cheapla.Business.Services;
using Cheapla.Data.Contexts;
using Cheapla.Data.Repositories;
using Cheapla.WebUI.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

CultureUtil cultureUtil = new CultureUtil("en-US");

builder.Services.Configure(cultureUtil.AddCulture());

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<CheaplaContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<IUserService, UserManager>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICartService, CartManager>();

builder.Services.AddScoped<ICommentService, CommentManager>();


builder.Services.AddDataProtection();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});



var app = builder.Build();

app.UseRequestLocalization(cultureUtil.UseCulture());

app.UseAuthentication();

app.UseAuthorization();



app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{Controller=Dashboard}/{Action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: ("{Controller=Home}/{Action=Index}/{id?}")
    );

app.Run();
