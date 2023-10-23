using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paws.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<mvcAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDbConnection")));

builder.Services.AddDbContext<AuthDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AuthDbConnection")));

//identity configuration:
builder.Services.AddIdentity<IdentityUser, IdentityRole>()       // identity framework
  .AddEntityFrameworkStores<AuthDbContext>();


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;

});


/*builder.Services.AddDbContext<mvcAppDbContext>(options =>
    options.UseSqlServer(connectionString));
*/
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

