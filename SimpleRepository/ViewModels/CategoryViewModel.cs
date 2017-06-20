using System.ComponentModel.DataAnnotations;

namespace SimpleRepository.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
    }
}
