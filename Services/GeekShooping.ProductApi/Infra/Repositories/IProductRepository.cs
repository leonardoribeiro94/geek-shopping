using GeekShooping.ProductApi.Entities;

namespace GeekShooping.ProductApi.Infra.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();

        Task<Product> FindById(long id);

        Task<Product> Create(Product product);

        Task<Product> Update(Product product);

        Task<bool> Delete(long id);
    }
}