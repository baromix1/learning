using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context){
            if(!context.ProductBrands.Any()){
                var brandsData=File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);

            }
            if(!context.ProductTypes.Any()){
                var TypesData=File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var Types=JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                context.ProductTypes.AddRange(Types);

            }
            if(!context.Products.Any()){
                var ProductsData=File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var Products=JsonSerializer.Deserialize<List<Product>>(ProductsData);
                context.Products.AddRange(Products);

            }
            if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        } 
    }
}