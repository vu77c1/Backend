using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSQL.Data
{
    [Table("Category")]
    public class Category
    {
        [Key]
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
        public string Description { get; set; }
		public virtual List<Product> Products { get; set; }

	}
}

