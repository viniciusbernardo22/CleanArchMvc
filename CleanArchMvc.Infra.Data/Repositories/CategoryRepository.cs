using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Category> GetbyId(int id) => await _context.Categories.FindAsync(id);
        
        public async Task<IEnumerable<Category>> GetCategories() => await _context.Categories.ToListAsync();
        
        public async Task<Category> Create(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        
        public async Task<Category> Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Delete(Category category)
        {
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}