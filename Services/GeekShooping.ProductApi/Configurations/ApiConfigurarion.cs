using GeekShooping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MySqlContext>(options =>
            {
                var connectionString = configuration["connectionString:mysqlConnectionString"];

                options.UseMySql(connectionString,
                    new MySqlServerVersion(new Version("8.0.32")));
            });

            //AutoMapper
            var mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}