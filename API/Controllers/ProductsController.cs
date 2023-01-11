using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository Repo;
        public ProductsController(IProductRepository repo) {
            Repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() { 
            var products = await Repo.GetProductsAsync(); 

            return Ok(products);
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> GetProduct(int id) { 
            // var prod = await Context.Products.FindAsync(id);
            // if(prod == null) {
            //     return NotFound();
            // }
            return await Repo.GetProductByIdAsync(id); 
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() 
        {
            return Ok(await Repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType() 
        {
            return Ok(await Repo.GetProductTypesAsync());
        }
        
    }
}