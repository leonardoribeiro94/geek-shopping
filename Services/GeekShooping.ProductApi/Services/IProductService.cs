using GeekShooping.ProductApi.Data.ValueObjects;

namespace GeekShooping.ProductApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> FindAll();

        Task<ProductDto> FindById(long id);

        Task<ProductDto> Create(ProductDto vo);

        Task<ProductDto> Update(ProductDto vo);

        Task<bool> Delete(long id);
    }
}