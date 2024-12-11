using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Author Name is required")]
        public required string Name { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Biography { get; set; }
        public string? Picture { get; set; }
    }
}
