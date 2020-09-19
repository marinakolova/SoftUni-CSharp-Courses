namespace PetStore.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
