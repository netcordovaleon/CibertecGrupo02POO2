using AppStore.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Global.asax / Startup.cs / Program.cs
builder.Services.AddControllersWithViews();

//Cadena de conexion SQL Server
//builder.Configuration.GetConnectionString("StoreCnx");
builder.Services.AddDbContext<BDStoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreSQLConnection"));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
