using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.DTOs
{
    public class PaginationDTo
    {
        public int Page { get; set; }
        private int recordPerPage = 10;
        private readonly int maxAmount = 50;

        public int RecordPerPage
        {
            get { return recordPerPage; }
            set
            {
                recordPerPage = (value > maxAmount)?maxAmount : value;
            }
        }
    }
}
