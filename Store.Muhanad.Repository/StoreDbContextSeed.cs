using Store.Muhanad.Core.Entities;
using Store.Muhanad.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Muhanad.Repository
{
    public static class StoreDbContextSeed
    {
        public async static Task Seed(StoreDbContext _context)
        {
            if(_context.Brands.Count() == 0)
            {
                //1:Read from json file
               var brandsdata =  File.ReadAllText(@"..\Store.Muhanad.Repository\Data\DataSeed\brands.json");

               var brands= JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                if(brands is not null && brands.Count() > 0)
                {
                   await _context.Brands.AddRangeAsync(brands);
                   await _context.SaveChangesAsync();
                }
            }

            if(_context.Types.Count() == 0)
            {
                var typesdata = File.ReadAllText(@"..\Store.Muhanad.Repository\Data\DataSeed\types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                if(types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }
            }

            if(_context.Products.Count() == 0)
            {
                var productsdata = File.ReadAllText(@"..\Store.Muhanad.Repository\Data\DataSeed\products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                if(products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
