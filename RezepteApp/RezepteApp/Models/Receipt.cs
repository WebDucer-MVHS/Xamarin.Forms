namespace RezepteApp.Models
{
    public class Receipt
    {
        public string Title { get; set; }
        public bool IsFavorit { get; set; } = false;
        public string Ingredient { get; set; }
        public string Steps { get; set; }
    }
}
