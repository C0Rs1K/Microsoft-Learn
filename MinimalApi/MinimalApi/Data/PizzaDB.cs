using Microsoft.EntityFrameworkCore;
using MinimalApi.Models;

namespace MinimalApi.Data
{
    class PizzaDB : DbContext
    {
        public PizzaDB(DbContextOptions options) 
            : base(options) 
        { 
        }
        
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
