using WebApp.Helpers.Repositories;
using WebApp.Models;
using WebApp.Models.dto;
using WebApp.Models.dtos;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly ProductCategoryService _categoryService;
        private readonly TagService _tagService;
        private readonly ProductTagRepository _productTagRepository;
        private readonly IWebHostEnvironment _environment;



        public ProductService(ProductRepository productRepo, IWebHostEnvironment environment, ProductCategoryService categoryService, TagService tagService, ProductTagRepository productTagRepository)
        {
            _productRepo = productRepo;
            _environment = environment;
            _categoryService = categoryService;
            _tagService = tagService;
            _productTagRepository = productTagRepository;
        }

        public async Task<Product> CreateAsync(ProductEntity entity)
        {
            var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
            if (_entity == null)
            {
                _entity = await _productRepo.AddAsync(entity);
                if (_entity != null)
                    return _entity;
            }
            return null!;
        }

        public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
        {
            foreach(var tag in tags)
            {
                await _productTagRepository.AddAsync(new ProductTagEntity
                {
                    ArticleNumber = entity.ArticleNumber,
                    TagId = int.Parse(tag)
                });
            }
        }





        /*
                public async Task<Product> CreateAsync(ProductRegistrationViewModel viewModel)
                {
                    ProductEntity entity = viewModel;

                    if (await _categoryService.GetCategoryAsync(entity.ProductCategoryId) != null) 
                    { 
                        entity = await _productRepo.AddAsync(entity);

                    if (entity != null)
                        {
                        foreach(var tagName in viewModel.Tags)
                            {
                                var tag = await _tagService.GetTagAsync(tagName);
                                tag ??=await _tagService.CreateTagAsync(tagName);

                                await _tagRepository.AddAsync(new ProductTagEntity
                                {
                                    ArticleNumber = viewModel.ArticleNumber,
                                    TagId = tag.Id,
                                });
                            }
                        return await GetAsync(entity.ArticleNumber);
                        } 


                    }
                    return null!;

                }
         */
        public async Task<Product> GetAsync(string articlenumber)
        {
            var entity = await _productRepo.GetAsync(x => x.ArticleNumber== articlenumber);
        if (entity != null)
            {
                Product product = entity;

                if (entity.ProductTags.Count > 0)
                {
                    var tagList = new List<Tag>();

                    foreach (var productTag in entity.ProductTags)
                        tagList.Add(new Tag { Id = productTag.Tag.Id, TagName = productTag.Tag.TagName });
                    product.Tags = tagList;
                }
                return product;
            }
         return null!; 
        }

        public async Task<bool> UploadImageAsync(Product product, IFormFile image)
        {
            try

            {
                string imagesPath = $"{_environment.WebRootPath}/images/placeholders/{product.ImageUrl}";
                await image.CopyToAsync(new FileStream(imagesPath, FileMode.Create));
                return true;

            }
            catch { return false; }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            var list = new List<Product>();
            foreach (var product in products)
                list.Add(product);

            return list;
        }

        public async Task<IEnumerable<Product>> GetRandomProductsAsync(int count)
        {
            var allProducts = await GetAllAsync();
            var randomProducts = allProducts.OrderBy(x => Guid.NewGuid()).Take(count);

            return randomProducts;
        }

    }

}

