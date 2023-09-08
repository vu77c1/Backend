using System;
using Microsoft.EntityFrameworkCore;

namespace MSQL.Data
{
    public class MsqlContext : DbContext
    {
        public MsqlContext(DbContextOptions<MsqlContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImport> BooksImport { get; set; }
    }
}

