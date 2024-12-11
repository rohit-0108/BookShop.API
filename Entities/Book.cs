using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(maximumLength:80)]
        public required string Title { get; set; }
        public string Summary { get; set; }
        public string Cover { get; set; }
        public bool  IsAvailable { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
        public List<BookCategory> BookCategories  { get; set; }
        public List<BooksShop> BookShops  { get; set; }
    }
}
