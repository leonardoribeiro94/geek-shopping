using GeekShooping.ProductApi.Entities;
using GeekShooping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShooping.ProductApi.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;

        public ProductRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> FindById(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> Delete(long id)
        {
            var product = await _context.Products
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}