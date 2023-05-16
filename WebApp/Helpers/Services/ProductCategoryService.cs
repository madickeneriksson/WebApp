using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Helpers.Repositories;
using WebApp.Models.dtos;
using WebApp.Models.Entities;
using WebApp.Models.Schemas;
using WebApp.ViewModels;

namespace WebApp.Helpers.Services
{
    public class ProductCategoryService
    {
        private readonly ProductCategoryRepository _productRepo;

        public ProductCategoryService(ProductCategoryRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ProductCategory> CreateCategoryAsync(string categoryName)
        {
            var entity = new ProductCategoryEntity { CategoryName = categoryName };
            var result = await _productRepo.AddAsync(entity);
            return result;
        }


        public async Task<ProductCategory> CreateCategoryAsync(ProductCategoryViewModel viewModel)
        {
            var result = await _productRepo.AddAsync(viewModel);
            return result;
        }

        public async Task<ProductCategory> GetCategoryAsync(string categoryName)
        {
            var result = await _productRepo.GetAsync(x => x.CategoryName == categoryName);
            return result;
        }

        public async Task<List<SelectListItem>> GetAllCategoryAsync()
        {
            var categorys = new List<SelectListItem>();
            foreach (var category in await _productRepo.GetAllAsync())
            {
                categorys.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName
                });
            }
            return categorys;
        }

        public async Task<List<SelectListItem>> GetAllCategoryAsync(string[] selectedCategorys)
        {
            var categorys = new List<SelectListItem>();
            foreach (var category in await _productRepo.GetAllAsync())
            {
                categorys.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.CategoryName,
                    Selected = selectedCategorys.Contains(category.Id.ToString())
                    
                });
            }
            return categorys;
        }

        public async Task<ProductCategory> GetCategoryAsync(int id)
        {
            var result = await _productRepo.GetAsync(x => x.Id == id);
            return result;
        }

        public async Task<ProductCategory> GetCategoryAsync(ProductCategoryViewModel viewModel)
        {
            var result = await _productRepo.GetAsync(x => x.CategoryName == viewModel.CategoryName);
            return result;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoryAsync()
        {
            var result = await _productRepo.GetAllAsync();
            var list = new List<ProductCategory>();
            foreach (var category in result)
                list.Add(category);
            return list;
        }
    }
}
