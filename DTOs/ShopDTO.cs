using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Lomgitude { get; set; }
        public double Latitude { get; set; }
    }
}
