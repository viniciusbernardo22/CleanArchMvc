using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name,description, price, stock, image);
            
        }
        
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name,description, price, stock, image);
        }
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        
        public Category Category { get;  set; }
        
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name is Required");
            
            DomainExceptionValidation.When(name?.Length < 3, "Invalid name, Name is too short and require the minimum of 3 characters");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, Description is Required");
            
            DomainExceptionValidation.When(price < 0, "Invalid price value");
            
            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, maximum image name: 250 characters");
            
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        
        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name,description, price, stock, image);
            CategoryId = CategoryId;
        }

    }
}