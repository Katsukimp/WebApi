using WebApiAspNetCore.Domain.Entities.Base;

namespace WebApiAspNetCore.Domain.Entities
{
    public class Product : BaseModel
    {
        public Product(string description, double price, int quantity, Guid idCategory)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
            IdCategory = idCategory;
        }
        
        public Product(string description, double price, int quantity)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        /// <summary>
        /// Descrição do produto
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Preço do produto
        /// </summary>
        public double Price { get; set; }
        
        /// <summary>
        /// Quantidade do produto
        /// </summary>
        public int Quantity { get; set; }

        public Category? Category { get; set; }
        /// <summary>
        /// Categoria do produto
        /// </summary>
        public Guid? IdCategory { get; set; }
    }
}
