using API.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public StoreContext Context { get; set;}
        public ProductsController(StoreContext context) {
            Context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() { 
            var products = await Context.Products.ToListAsync(); 

            return Ok(products);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(int id) { 
            var prod = await Context.Products.FindAsync(id);
            if(prod == null) {
                return NotFound();
            }
            return prod;
        }
        
    }
}