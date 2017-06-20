using System.ComponentModel.DataAnnotations;

namespace SimpleRepository.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Category is required.")]
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        public CategoryViewModel Category { get; set; }

    }
}
