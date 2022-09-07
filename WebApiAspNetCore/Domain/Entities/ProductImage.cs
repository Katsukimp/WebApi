using WebApiAspNetCore.Domain.Entities.Base;

namespace WebApiAspNetCore.Domain.Entities
{
    public class ProductImage : BaseModel
    {
        public ProductImage(string filename, IFormFile file, int size, Guid idProduct, Product product)
        {
            Filename = filename;
            File = file;
            Size = size;
            Active = true;
            CreateAt = DateTime.Now;
            IdProduct = idProduct;
            Product = product;
        }

        /// <summary>
        /// Nome da imagem
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Arquivo da imagem
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// Tamanho da imagem
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Produto referente a imagem
        /// </summary>
        public Product Product { get; set; }
        public Guid IdProduct { get; set; }

        /// <summary>
        /// Mostra se a imagem está ativa
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Data em que a imagem foi adicionada
        /// </summary>
        public DateTime CreateAt { get; set; }
    }
}
