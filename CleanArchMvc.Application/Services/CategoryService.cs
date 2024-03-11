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
            var categoriesEntity = await _repository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var categoryEntity = await _repository.GetbyId(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var CategoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Create(CategoryEntity);
            
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var CategoryEntity = _mapper.Map<Category>(categoryDto);
            await _repository.Update(CategoryEntity);

        }

        public async Task Delete(int id)
        {
            var CategoryEntity = _repository.GetbyId(id).Result;
            await _repository.Delete(CategoryEntity);
        }
    }
}