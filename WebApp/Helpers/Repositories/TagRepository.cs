using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories
{
    public class TagRepository : Repository<TagEntity>
    {
        public TagRepository(IdentityContext context) : base(context)
        {
        }
    }
}
