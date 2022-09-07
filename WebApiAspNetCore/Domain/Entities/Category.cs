using WebApiAspNetCore.Domain.Entities.Base;

namespace WebApiAspNetCore.Domain.Entities
{
    public class Category : BaseModel
    {
        public Category(string name)
        {
            Name = name;
        }
    
        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string Name { get; set; }
    }
}
