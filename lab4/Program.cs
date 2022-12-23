using lab4.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var optionsbuilder = new DbContextOptionsBuilder<LibraryContext>();

string connectionString = builder.Configuration.GetConnectionString("Library");

// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options => optionsbuilder.UseSqlServer(connectionString));
builder.Services.AddScoped<DbContext, LibraryContext>();
builder.Services.AddControllersWithViews();

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
