using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSQL.Data
{
    [Table("Product")]   
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductImage { get; set; }
        public string Description { get; set; }
		public decimal Price { get; set; } 
		public virtual Category Category { get; set; }
	}
}

