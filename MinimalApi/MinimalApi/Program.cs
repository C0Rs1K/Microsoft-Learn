using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Pizza API",
        Version = "v1",
        Description = "Making the Pizzas you love",
    });
});
builder.Services.AddSqlite<PizzaDB>(builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(a =>
{
    a.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza API");
});

app.MapGet("/pizzas", async (PizzaDB db) => await db.Pizzas.ToListAsync());
app.MapGet("/pizza/{id}", async (PizzaDB db, int id) => await db.Pizzas.FindAsync(id));
app.MapPost("/pizzas", async (PizzaDB db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});
app.MapPut("/pizza/{id}", async (PizzaDB db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/pizza/{id}", async (PizzaDB db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null) return Results.NotFound();
    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.Run();
