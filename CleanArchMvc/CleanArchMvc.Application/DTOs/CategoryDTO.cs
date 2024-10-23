using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
