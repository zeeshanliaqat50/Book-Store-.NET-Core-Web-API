using System.ComponentModel.DataAnnotations; //this package is used for model validations which mapped to database
namespace BookStoreWebAPI.Data
{
    public class Book
    {
        
        public int id { get; set; }
        [Required(ErrorMessage ="Title required")]
        public String title { get; set; }
        [Required(ErrorMessage ="Description required")]
        public String description { get; set; }

    }
}
