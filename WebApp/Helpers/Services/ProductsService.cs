using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Helpers.Services
{
    public class ProductsService
    {
        private readonly IdentityContext _context;

        public ProductsService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
        {
            try
            {
                ProductEntity productEntity = productRegistrationViewModel;

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
        
            public async Task<IEnumerable<ProductModel>> GetAllAsync()
            {
                var products = new List<ProductModel>();
                var items = await _context.Products.ToListAsync();
                foreach (var item in items)
                {
                    ProductModel productModel = item;
                    products.Add(productModel);
                }
                return products;
            }
        
    }

}
