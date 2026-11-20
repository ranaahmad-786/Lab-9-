using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Lab9.Data.AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Lab9.Data.AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Products.Any())
    {
        db.Products.AddRange(
            new Lab9.Models.Product
            {
                Name = "Laptop",
                Description = "A lightweight computer for study and projects.",
                Price = 55000m,
                StockQuantity = 12
            },
            new Lab9.Models.Product
            {
                Name = "Notebook",
                Description = "A ruled notebook for lab notes.",
                Price = 250m,
                StockQuantity = 30
            });
        db.SaveChanges();
    }
}

app.Run();
