using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public interface DIProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int productId);
    }
}
