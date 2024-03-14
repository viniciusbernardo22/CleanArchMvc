using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        
        public ProductService(IMapper mapper, IProductRepository repository)
        {
            _repository = repository ??
                          throw new ArgumentNullException(nameof(repository));
            
            _mapper = mapper;
        }
        
        
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntities = await _repository.GetProducts();
            
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntities);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = await _repository.GetbyIdAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);

        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await _repository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _repository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);

            await _repository.UpdateAsync(productEntity);

        }

        public async Task Delete(int id)
        {
            var productEntity = _repository.GetbyIdAsync(id).Result;
            await _repository.DeleteAsync(productEntity);
           
        }
    }
}