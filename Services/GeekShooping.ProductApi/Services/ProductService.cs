using AutoMapper;
using GeekShooping.ProductApi.Data.ValueObjects;
using GeekShooping.ProductApi.Entities;
using GeekShooping.ProductApi.Infra.Repositories;

namespace GeekShooping.ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            var product = await _productRepository.FindAll();

            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> FindById(long id)
        {
            var product = await _productRepository.FindById(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Create(ProductDto vo)
        {
            var productMap = _mapper.Map<Product>(vo);
            await _productRepository.Create(productMap);

            return vo;
        }

        public async Task<bool> Delete(long id)
        {
            return await _productRepository.Delete(id);
        }

        public async Task<ProductDto> Update(ProductDto vo)
        {
            var productMap = _mapper.Map<Product>(vo);
            await _productRepository.Update(productMap);

            return vo;
        }
    }
}