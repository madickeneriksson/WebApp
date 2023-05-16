using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class ProductCategoryRepository : Repository<ProductCategoryEntity>
    {
        public ProductCategoryRepository(IdentityContext context) : base(context)
        {
        }
    }
}
