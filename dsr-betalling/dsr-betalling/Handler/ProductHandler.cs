using System.Collections.Generic;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    internal class ProductHandler
    {
        /// <summary>
        ///     Gets a product, by Product Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static async Task<Product> GetProduct(int Id)
        {
            return await Facade.GetAsync(new Product(), Id);
        }

        /// <summary>
        ///     Adds a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static async Task<bool> AddProduct(Product product)
        {
            return await Facade.PostAsync(product);
        }

        /// <summary>
        ///     Updates a Products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static async Task<bool> UpdateProduct(Product product)
        {
            return await Facade.PutAsync(product, product.Id);
        }

        /// <summary>
        ///     Deletes a Product, by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteProduct(int productId)
        {
            return await Facade.DeleteAsync(new Product(), productId);
        }

        /// <summary>
        ///     Deletes a Product, by product Object
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static async Task<bool> DeleteProduct(Product product)
        {
            return await Facade.DeleteAsync(new Product(), product.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Product>> GetProductList()
        {
            return await Facade.GetListAsync(new Product());
        }
    }
}