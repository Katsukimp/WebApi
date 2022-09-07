using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Domain.Interfaces.Repositories;
using WebApiAspNetCore.Domain.Interfaces.Services;
using WebApiAspNetCore.Domain.Services;
using WebApiAspNetCore.Domain.Validator;
using WebApiAspNetCore.Infrastructure.Data.Commom;
using WebApiAspNetCore.Infrastructure.Data.Repositories;

namespace WebApiAspNetCore.Infrastructure.ExtensionMethods
{
    public static class CommomDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICategoryService, CategoryService>();
            return services;
        }

        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ClientValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<ProductValidator>(ServiceLifetime.Transient);
            services.AddValidatorsFromAssemblyContaining<CategoryValidator>(ServiceLifetime.Transient);
            return services;
        }

        public static IServiceCollection AddSqliteContext(this IServiceCollection services)
        {
            services.AddDbContext<RegisterContext>(options =>
                options.UseSqlite("Data Source=database.db"));

            return services;
        }
    }
}
