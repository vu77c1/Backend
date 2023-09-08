using MSQL.Data;
namespace MSQL.Models.BookImportModel
{
    public class BookImportResponse
    {
        public int BookImportId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAt { get; set; }
        public decimal Price { get; set; }

        public BookImportResponse(BookImport bookImport)
        {
            BookImportId = bookImport.BookImportId;
            CategoryId = bookImport.CategoryId;
            CategoryName = bookImport.CategoryName;
            Quantity = bookImport.Quantity;
            DateAt = bookImport.DateAt;
            Price = bookImport.Price;

        }

    }
}