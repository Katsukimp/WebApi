using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Services.Base;

namespace WebApiAspNetCore.Domain.Services
{
    public class ProductImageService : ServiceBase<ProductImage>, IProductImageService
    {
        public ProductImageService(IProductImageRepository repository) : base(repository)
        {

        }
    }
}
