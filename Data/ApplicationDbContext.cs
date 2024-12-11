using BookShop.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories  { get; set; }
        public DbSet<BooksShop> BooksShops  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookAuthor>().HasKey(x => new {x.BookId,x.AuthorId});
            builder.Entity<BookCategory>().HasKey(x => new {x.BookId,x.CategoryId});
            builder.Entity<BooksShop>().HasKey(x => new {x.BookId,x.ShopId});
            base.OnModelCreating(builder);
        }
    }
}
