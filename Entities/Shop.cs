using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required")]
        [StringLength(maximumLength:80)]
        public required  string Name { get; set; }
        public Point Location { get; set; }
    }
}
