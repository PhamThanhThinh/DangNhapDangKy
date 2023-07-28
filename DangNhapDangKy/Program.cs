using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DangNhapDangKy.Data;
using DangNhapDangKy.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DangNhapDangKyDBContextConnection") ?? throw new InvalidOperationException("Connection string 'DangNhapDangKyDBContextConnection' not found.");

builder.Services.AddDbContext<DangNhapDangKyDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<DangNhapDangKyUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DangNhapDangKyDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
// Thêm các dịch vụ cho Razor Pages vào ứng dụng
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
