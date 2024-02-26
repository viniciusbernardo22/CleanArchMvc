using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact(DisplayName = "Create Product with Valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with negativeId")]
        public void CreateProduct_NegativeIdValue_DomainException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with empty string name")]
        public void CreateProduct_EmptyStringName_DomainException()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is Required");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with short string name")]
        public void CreateProduct_ShortName_DomainException()
        {
            Action action = () => new Product(1, "pr", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name is too short and require the minimum of 3 characters");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with empty string description")]
        public void CreateProduct_EmptyDescription_DomainException()
        {
            Action action = () => new Product(1, "product 1", "", 9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, Description is Required");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with Invalid price value")]
        public void CreateProduct_InvalidPricevalue_DomainException()
        {
            Action action = () => new Product(1, "product 1", "description", -9.99m, 99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with Invalid stock value")]
        public void CreateProduct_InvalidStockvalue_DomainException()
        {
            Action action = () => new Product(1, "product 1", "description", 9.99m, -99, "product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
        
        [Fact(DisplayName = "Throw error when try to create instance with Invalid stock value")]
        public void CreateProduct_InvalidImageLength_DomainException()
        {
            Action action = () => new Product(1, "product 1", "description", 9.99m, 99, 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam eget ligula eu lectus lobortis condimentum. Aliquam nonummy auctor massa. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla at risus. Quisque purus magna, auctor et, sagittis ac, posuere eu, lectus. Nam mattis, felis ut adipiscing");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, maximum image name: 250 characters");
        }
        
        [Fact(DisplayName = "Create Product with null image")]
        public void CreateProduct_WithnullImage_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact(DisplayName = "Create Product with null image name without Null referece exception")]
        public void CreateProduct_WithemptyStringImage_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
        
        [Fact(DisplayName = "Create Product with empty string image")]
        public void CreateProduct_WithemptyStringImage_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        
        
    }
}