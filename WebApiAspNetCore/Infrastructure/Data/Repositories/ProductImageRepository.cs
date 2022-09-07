using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Infrastructure.Data.Commom;
using WebApiAspNetCore.Infrastructure.Data.Repositories.Base;

namespace WebApiAspNetCore.Infrastructure.Data.Repositories
{
    public class ProductImageRepository : RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(RegisterContext context) : base(context)
        {

        }
    }
}
