using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class AuthorBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}
