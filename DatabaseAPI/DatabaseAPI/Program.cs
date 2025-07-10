using DatabaseAPI.Data;
using DatabaseAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(opt => opt.UseInMemoryDatabase("MainDatabase"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MainContext>();
    context.Database.EnsureCreated();
    // Seed data if necessary
    if (!context.Activities.Any())
    {
        context.Activities.Add(new Activity { Description = "Do homework" });
        context.Activities.Add(new Activity { Description = "Play videogame" });
        context.Activities.Add(new Activity { Description = "Go to the movies" });
        context.SaveChanges();
    }
}

app.Run();
