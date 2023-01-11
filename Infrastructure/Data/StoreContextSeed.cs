using System.Text.Json;
using API.Data;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var items in brands)
                    {
                        context.ProductBrands.Add(items);
                    }

                    await context.SaveChangesAsync();
                }
                
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var items in types)
                    {
                        context.ProductTypes.Add(items);
                    }

                    await context.SaveChangesAsync();
                }

                   if (!context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                    foreach (var items in products)
                    {
                        context.Products.Add(items);
                    }

                    await context.SaveChangesAsync();
                }
            }

            catch (Exception ex) { 
                var logger = loggerFactory.CreateLogger<StoreContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}