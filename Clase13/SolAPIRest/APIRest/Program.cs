using APIRest.Database;
using APIRest.Interfaces;
using APIRest.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPetLogic, PetSQLLogic>();

builder.Services.AddDbContext<PetContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PetDB"),
        ef => ef.MigrationsAssembly(typeof(PetContext).Assembly.FullName)
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
