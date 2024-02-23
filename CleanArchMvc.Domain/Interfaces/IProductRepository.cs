using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCategories();

        Task<Product> GetbyIdAsync(int id);
        
        Task<Product> GetProductCategoryAsync(int id);

        Task<Product> CreateAsync(Product category);
        
        Task<Product> UpdateAsync(Product category);
        
        Task<Product> DeleteAsync(Product category);

    }
}