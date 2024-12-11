using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Extensions
{
    public static class HttpContextExtensions
    {
        public async static Task SetResponseHeader<T>(this HttpContext httpContext,
            IQueryable<T> querable)
        {
            if(httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            int count= await querable.CountAsync();
            httpContext.Response.Headers.Add("totalAmountOfRecords",count.ToString());
        }
    }
}
