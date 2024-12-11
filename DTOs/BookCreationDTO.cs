using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class BookCreationDTO
    {
        public required string Title { get; set; }
        public string Summary { get; set; }
        public IFormFile Cover { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> AuthorIds { get; set; }
        public List<int> ShopIds { get; set; }
    }
}
