namespace WebApp.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Rating { get; set; }

        public string? Category { get; set; }
        public decimal Price { get; set; }

    }
}
