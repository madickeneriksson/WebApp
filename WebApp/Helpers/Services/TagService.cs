
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Helpers.Repositories;
using WebApp.Models.dtos;
using WebApp.Models.Entities;

using WebApp.ViewModels;

namespace WebApp.Helpers.Services
{
    public class TagService
    {
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity
            {
                TagName = tagName,
            };
            var result = await _tagRepo.AddAsync(entity);
            return result;
        }

        public async Task<Tag> CreateTagAsync(ProductTagViewModel viewModel)
        { 
            var result = await _tagRepo.AddAsync(viewModel);
            return result;
        }

        public async Task<Tag>GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return result;
        }

        public async Task<Tag> GetTagAsync(ProductTagViewModel viewModel)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == viewModel.TagName);
            return result;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();
            var list =new List<Tag>();
            foreach (var tag in result) 
                list.Add(tag);
            return list;
        }

        public async Task<List<SelectListItem>> GetAllTagsAsync()
        {
            var tags = new List<SelectListItem>();
            foreach(var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName
                });
            }
            return tags;
        }

        public async Task<List<SelectListItem>> GetAllTagsAsync(string[] selectedTags)
        {
            var tags = new List<SelectListItem>();
            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.TagName,
                    Selected = selectedTags.Contains(tag.Id.ToString())
                });
            }
            return tags;
        }





        public async Task<Tag> UpdateTagsAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            if (entity != null) 
            {
                entity.TagName= tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }
            return null!;
        }

        public async Task<bool> DeleteTagAsync (int id)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == id);
            return await _tagRepo.DeleteAsync(entity);  
        }

        public async Task<bool> DeleteTagAsync(string tagName)
        {
            var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return await _tagRepo.DeleteAsync(entity);
        }

        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            return await _tagRepo.DeleteAsync(entity);
        }

    }
}
