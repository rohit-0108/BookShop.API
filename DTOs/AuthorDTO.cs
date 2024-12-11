using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
    
        public required string Name { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Biography { get; set; }
        public string? Picture { get; set; }
    }
}
