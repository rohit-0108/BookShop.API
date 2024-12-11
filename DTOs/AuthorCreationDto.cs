using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class AuthorCreationDto
    {
        public required string Name { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? Biography { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
