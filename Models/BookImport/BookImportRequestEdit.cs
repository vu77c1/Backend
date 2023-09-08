namespace MSQL.Models.BookImportModel
{
    public class BookImportRequestEdit
    {
        public int BookImportId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAt { get; set; }
        public decimal Price { get; set; }
    }
}