using Småstad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//add the repository to the services container
builder.Services.AddTransient<ISmåstadRepository, EFSmåstadRepository>();
//DB context configuration
builder.Services.AddDbContext<SmåStadDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Identity configuration
builder.Services.AddDbContext<AppIdentityDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
//services for authentication and authorization
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  .AddEntityFrameworkStores<AppIdentityDBContext>()
  .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
  options.LoginPath= "/Account/Login";
  options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  DBinitializer.EnsurePopulated(services);
  IdentityInitializer.EnsurePopulated(services).Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
