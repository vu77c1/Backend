using System.ComponentModel.DataAnnotations;

namespace MSQL.Data
{
    public class BookImport
    {
        [Key]
        public int BookImportId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAt { get; set; }
        public decimal Price { get; set; }
    }
}