using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
    }
}
