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
        private readonly IWebHostEnvironment _environment;

        public ProductsService(IdentityContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
                return false!;
            }

        }

        public async Task<bool> UploadImageAsync(ProductModel productModel, IFormFile image)
        {
            try
            
                {
                    string imagesPath = $"{_environment.WebRootPath}/images/placeholders/{productModel.ImageUrl}";
                    await image.CopyToAsync(new FileStream(imagesPath, FileMode.Create));
                return true;

                }
            catch { return false; }
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

        internal Task UploadImageAsync(bool productModel, IFormFile image)
        {
            throw new NotImplementedException();
        }
    }

}
