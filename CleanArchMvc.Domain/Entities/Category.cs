using System.Collections;
using System.Collections.Generic;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        
        public Category(string name)
        {
            ValidateDomain(name);
        }
        
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            
            Id = id;
            ValidateDomain(name);
        }
        
        public ICollection<Product> Products { get; set; }


        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is Required");
            
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, Name is too short and require the minimum of 3 characters");

            Name = name;
        }
    }
}