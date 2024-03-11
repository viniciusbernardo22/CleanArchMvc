﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; private set; }
        
        [Required(ErrorMessage = "The description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; private set; }
        
        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18.2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; private set; }
        
        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get; private set; }
        
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; private set; }
        
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
        
        public Category Category { get;  set; }
        
    }
}