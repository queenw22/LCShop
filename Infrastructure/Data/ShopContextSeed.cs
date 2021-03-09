using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.EntitiesDb;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class ShopContextSeed
    {
        public static async Task SeedAsync(ShopContext context, ILoggerFactory logger)
        {
            try
            {
                if(!context.ItemBrands.Any())
                {
                    var brandsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<List<ItemBrand>>(brandsData);

                    foreach(var item in brands)
                    {
                        context.ItemBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.ItemTypes.Any())
                {
                    var typesData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<List<ItemType>>(typesData);

                    foreach(var item in types)
                    {
                        context.ItemTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.Items.Any())
                {
                    var itemsData = 
                    File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var items = JsonSerializer.Deserialize<List<Item>>(itemsData);

                    foreach(var item in items)
                    {
                        context.Items.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var log = logger.CreateLogger<ShopContextSeed>();
                log.LogError(ex.Message);
            }
        }
    }
}