using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProjectWeb.Models
{
    public class BagContext: DbContext
    {
        public DbSet<Product>Products {get;set;}

        public BagContext(DbContextOptions<BagContext> options): base(options)
        {
        }
    }
    
    public class Product{
        public int Id {get;set;}
        public string Name {get;set;}
        public string Category {get;set;}
    }
}