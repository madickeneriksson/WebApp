using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductRepository : Repository<ProductEntity>
    {
        public ProductRepository(IdentityContext context) : base(context)
        {
        }
    }
}
