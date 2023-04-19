using GeekShooping.ProductApi.Data.ValueObjects;
using GeekShooping.ProductApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service ?? throw new
                ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> FindAll()
        {
            var products = await _productService.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> FindById(long id)
        {
            var product = await _productService.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _productService.Create(productDto);
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDto>> Update(ProductDto productDto)
        {
            if (productDto == null) return BadRequest();
            var product = await _productService.Update(productDto);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productService.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}