namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string CategoryName { get; set; }
    }
}
