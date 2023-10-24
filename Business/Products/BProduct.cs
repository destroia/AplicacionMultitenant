using Data.Products;
using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Products
{
    public class BProduct : BIProduct
    {
        readonly DIProduct Repo;
        public BProduct(DIProduct repo)
        {
            Repo = repo;
        }
        public async Task<Product> Create(Product product)
        {
            return await Repo.Create(product);
        }

        public async Task<bool> Delete(int productId)
        {
            return await Repo.Delete(productId);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Repo.GetAll();
        }

        public async Task<Product> Update(Product product)
        {
            return await Repo.Update(product);
        }
    }
}
