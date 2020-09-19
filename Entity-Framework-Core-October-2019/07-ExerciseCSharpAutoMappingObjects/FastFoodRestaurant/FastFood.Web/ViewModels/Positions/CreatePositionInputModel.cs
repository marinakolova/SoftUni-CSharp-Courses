namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    public class CreatePositionInputModel
    {
        [Required]
        [MinLength(3)]
        public string PositionName { get; set; }
    }
}
