using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetbyId(int id);

        Task<Category> Create(Category category);
        
        Task<Category> Update(Category category);
        
        Task<Category> Delete(Category category);

    }
}