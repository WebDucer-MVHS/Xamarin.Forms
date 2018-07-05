using System.ComponentModel.DataAnnotations;

namespace RezepteApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsFavorit { get; set; } = false;
        public string Ingredient { get; set; }
        public string Steps { get; set; }
        public int Rating { get; set; } = 0;

        public string Image { get; set; }
    }
}
