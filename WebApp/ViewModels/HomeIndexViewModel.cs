namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";

        public ShowcaseViewModel Showcase { get; set; } = null!;

        public GridCollectionViewModel New { get; set; } = null!;

        public FeaturedCompositeViewModel Featured { get; set; } = null!;

        public GridCollectionViewModel Popular { get; set; } = null!;
    }
}