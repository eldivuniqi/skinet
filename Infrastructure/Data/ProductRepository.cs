using API.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext Context;
        public ProductRepository(StoreContext context) { 
            Context = context;

        }

        public async Task<IReadOnlyList<Product>> GetProductBrandsAsync()
        {
            return (IReadOnlyList<Product>)await Context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await Context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductTypesAsync()
        {
            return (IReadOnlyList<Product>)await Context.ProductTypes.ToListAsync();
        }
    }
}