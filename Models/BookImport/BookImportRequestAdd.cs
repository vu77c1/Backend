namespace MSQL.Models.BookImportModel
{
    public class BookImportRequestAdd
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        // public DateTime DateAt { get; set; }
        public decimal Price { get; set; }
    }
}