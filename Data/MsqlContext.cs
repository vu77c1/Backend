using System;
using Microsoft.EntityFrameworkCore;

namespace MSQL.Data
{
	public class MsqlContext:DbContext
	{
        public MsqlContext(DbContextOptions<MsqlContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

