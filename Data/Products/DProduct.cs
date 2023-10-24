using Microsoft.EntityFrameworkCore;
using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public class DProduct : DIProduct
    {
        readonly ContextDBTenant DB;
        public DProduct(ContextDBTenant db)
        {
            DB = db;
        }
        public async Task<Product> Create(Product product)
        {
            try
            {
                var result = await DB.Products.AddAsync(product);
                await DB.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int productId)
        {
            try
            { 
                var result = await DB.Products.FindAsync(productId);
                DB.Products.Remove(result);
                await DB.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await DB.Products.ToListAsync();
        }

        public async Task<Product> Update(Product product)
        {
            try
            {
                var result = DB.Products.Update(product);
                await DB.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}
