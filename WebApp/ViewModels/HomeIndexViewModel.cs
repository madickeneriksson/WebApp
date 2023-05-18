namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel New { get; set; } = null!;

        public GridCollectionViewModel Featured { get; set; } = null!;

        public GridCollectionViewModel Popular { get; set; } = null!;
    }
}