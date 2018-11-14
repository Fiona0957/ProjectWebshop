using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;


namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    
    public class ProductsController : Controller{
        private readonly BagContext _context;

        public ProductsController (BagContext context){ _context = context;}
    
        
    
        // GET api/products
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var res = (from p in _context.Products orderby p.Id select p).ToList();

            return Ok(res);
        }

        // GET api/products/details/5
        [HttpGet("details/{id}")]
        public IActionResult GetProductDetails(int id)
        {
            var res = (from p in _context.Products  where p.Id == id select p);
            return Ok(res);
                    }

        // POST api/values
        [HttpPost]
        public void CreateNewProduct([FromBody] Product product)
        {    
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // PUT api/values/5
        
        [HttpPut("{id}")]
        public void UpdateExistingProduct(int id, [FromBody] Product product)
        {
           Product p = _context.Products.Find(id);
           if(product.Name != null){p.Name = product.Name;}
           if(product.Category != null){p.Category = product.Category;}
            _context.Update(p);
            _context.SaveChanges();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
           Product Product = _context.Products.Find(id);
           _context.Products.Remove(Product);
           _context.SaveChanges();
        }
    }
}
