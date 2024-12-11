using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        
        public required string Title { get; set; }
        public string Summary { get; set; }
        public string Cover { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<AuthorDTO> Authors { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<ShopDTO> Shops { get; set; }

    }
}
