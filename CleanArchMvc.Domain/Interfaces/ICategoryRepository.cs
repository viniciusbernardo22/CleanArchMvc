using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetbyIdAsync(int id);

        Task<Category> CreateAsync(Category category);
        
        Task<Category> UpdateAsync(Category category);
        
        Task<Category> DeleteAsync(Category category);

    }
}