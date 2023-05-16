using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using WebApp.Contexts;

namespace WebApp.Helpers.Repositories
{
    
    public abstract class Repository<TEntity> where TEntity : class
    {
        private readonly IdentityContext _context;

        protected Repository(IdentityContext context)
        {
            _context = context;
        }

        //virtual = överskrivningsbar

        //Skapa
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        //Hämta 
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var item = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                return item!;
            }
            catch  { return null!; }
            
        }
        //Hämta 
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();
                return items;
            }
            catch { return null!; }
        }

        //Hämta med filtrering
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var items = await _context.Set<TEntity>().Where(expression).ToListAsync();
                return items;
            } 
            catch { return null!; }
        }

        //Uppdatera
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
           try
            {
                _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch { return null!; }
        }

        // Ta bort
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
          try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch { return false; }
            
        }


    }
}
