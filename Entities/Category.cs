using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [StringLength(50)]
        public required string Name { get; set; }
    }
}
