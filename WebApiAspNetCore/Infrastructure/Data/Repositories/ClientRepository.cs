using WebApiAspNetCore.Domain.Entities;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Infrastructure.Data.Commom;
using WebApiAspNetCore.Infrastructure.Data.Repositories.Base;

namespace WebApiAspNetCore.Infrastructure.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RegisterContext context) : base(context)
        {

        }
    }
}
