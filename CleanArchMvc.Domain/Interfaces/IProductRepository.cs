using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product> GetbyIdAsync(int id);
        
        Task<Product> GetProductCategoryAsync(int id);

        Task<Product> CreateAsync(Product product);
        
        Task<Product> UpdateAsync(Product product);
        
        Task<Product> DeleteAsync(Product product);

    }
}