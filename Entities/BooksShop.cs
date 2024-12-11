using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Entities
{
    public class BooksShop
    {
        public int BookId { get; set; }
        public int ShopId { get; set; }
        public Book Book { get; set; }
        public Shop Shop { get; set; }

    }
}
