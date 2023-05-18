using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.dto;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        private readonly IdentityContext _context;
        public ProductRepository(IdentityContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var entity = await _context.Products
             //   .Include(x => x.ProductCategory)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(expression);
            if(entity != null)
                return entity!;

            return null!;
        }

        public async Task<IEnumerable<Product>> GetProductsByTagAsync(string tagName)
        {
            var products = await _context.Products
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p => p.ProductTags.Any(pt => pt.Tag.TagName == tagName))
                .ToListAsync();

            return products.Select(p => (Product)p).ToList();
        }
    }
}
