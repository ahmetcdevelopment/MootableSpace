using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mootableProject.Shared.Data.Abstract;
using mootableProject.Shared.Data.Concrete.EntityFramework;
using mootableProject.Shared.Entities.Concrete;
using MootableSpace.Business.Abstract;
using MootableSpace.Business.Concrete;
using MootableSpace.DataAccess.Abstract;
using MootableSpace.DataAccess.Concrete;
using MootableSpace.DataAccess.Concrete.EntityFramework;
using MootableSpace.DataAccess.Context;
using MootableSpace.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<mootableSpaceContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
// Add services to the container.
builder.Services.AddControllersWithViews();

#region Lifetime Scope
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMootService, MootManager>();
builder.Services.AddScoped<ICategoryService,  CategoryManager>();
builder.Services.AddScoped<ICommentService,  CommentManager>();
#endregion
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false; // þifrede rakam bulunsun mu?
    options.Password.RequiredLength = 5; // þifre en az kaç karakterden oluþsun?
    options.Password.RequiredUniqueChars = 0; // unique karakterlerden kaç tane olsun
    options.Password.RequireNonAlphanumeric = false;// küçük karakterler zorunlu kýlýnsýn mý?
    options.Password.RequireUppercase = false;// büyük karakterler zorunlu kýlýnsýn mý?

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
    options.User.RequireUniqueEmail = true; // tüm emailler eþsiz olsun mu?
}).AddEntityFrameworkStores<mootableSpaceContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/User/Login");
    options.Cookie = new CookieBuilder
    {
        Name = "mootable",
        HttpOnly = true,//kullanýcýnýn js ile bizim cookie bilgilerimizi görmesini engelliyoruz
        SameSite = SameSiteMode.Strict, //cookie bilgileri sadece kendi sitemizden geldiðinde iþlensin
        SecurePolicy = CookieSecurePolicy.SameAsRequest //always olmalý 
    };
    options.SlidingExpiration = true; //kullanýcý sitemize girdiðinde süre tanýnýyor
    options.ExpireTimeSpan = System.TimeSpan.FromMinutes(15); // 15 dakikatekrar giriþ gerekmeyecek
    options.AccessDeniedPath = new PathString("/Admin/User/AccessDenied"); //yetkisiz eriþim
});
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
app.UseAuthentication(); //sen kimsin?
app.UseAuthorization();//yetkilerin neler?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
