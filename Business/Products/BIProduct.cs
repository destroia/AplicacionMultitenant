using Models.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Products
{
    public interface BIProduct
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<bool> Delete(int productId);
    }
}
