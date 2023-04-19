using AutoMapper;
using GeekShooping.ProductApi.Infra.Repositories;
using GeekShooping.ProductApi.Services;

namespace GeekShooping.ProductApi.Configurations
{
    public static class DependenceInjectionConfig
    {
        public static void AddDependenceInjectionConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}