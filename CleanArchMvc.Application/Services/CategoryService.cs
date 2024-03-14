using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        
        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var categoriesEntity = await _repository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryEntity = await _repository.GetbyIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var CategoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.CreateAsync(CategoryEntity);
            
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var CategoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(CategoryEntity);

        }

        public async Task Delete(int id)
        {
            var CategoryEntity = _repository.GetbyIdAsync(id).Result;
            await _repository.DeleteAsync(CategoryEntity);
        }
    }
}