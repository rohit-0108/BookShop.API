using BookShop.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Extensions
{
    public static class QuerableExtensions
    {
        public static IQueryable<T> ToPaging<T>(this IQueryable<T> querable,PaginationDTo paginationDTo)
        {
            return querable.Skip((paginationDTo.Page - 1) * paginationDTo.RecordPerPage)
                .Take(paginationDTo.RecordPerPage);
        }
    }
}
