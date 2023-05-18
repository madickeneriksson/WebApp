using WebApp.Models.dto;

namespace WebApp.ViewModels;

public class GridCollectionViewModel
{
    public string? Title { get; set; }
    public IEnumerable<string> Categories { get; set; }
    public IEnumerable<Product> Products { get; set; }
    public bool LoadMore { get; set; }
}