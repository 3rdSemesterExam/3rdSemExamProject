using System.Collections.Generic;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    class ProductHandler
    {
        public static async Task<Product> GetProduct(int Id)
        {
            return await Facade.GetAsync(new Product(), Id);
        }

        public static async Task<bool> CreateProduct(Product product)
        {
            return await Facade.PostAsync(product);
        }
        public static async Task<bool> UpdateProduct(Product product)
        {
            return await Facade.PutAsync(product, product.Id);
        }
        public static async Task<bool> DeleteProduct(int productId)
        {
            return await Facade.DeleteAsync(new Product(), productId);
        }
        public static async Task<IEnumerable<Product>> GetProductList()
        {
            return await Facade.GetListAsync(new Product());
        }
    }
}
