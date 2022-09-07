using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Services.Base;

namespace WebApiAspNetCore.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {

        }
    }
}
