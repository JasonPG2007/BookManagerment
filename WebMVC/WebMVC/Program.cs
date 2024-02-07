using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.ReturnUrlParameter = "returnUrl";
}).AddCookie("Admin", options =>
{
    options.LoginPath = new PathString("/login");
}).AddCookie("User", options =>
{
    options.LoginPath = new PathString("/login");
}).AddCookie("Staff", options =>
{
    options.LoginPath = new PathString("/login");
});
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area=admin}/{controller=manager}/{action=Index}/{id?}");

app.Run();
