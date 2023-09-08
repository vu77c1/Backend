using MSQL.Data;

namespace MSQL.Models.BookModel
{
    public class BookResponse
    {
        public int BookId { get; set; }
        //Ten sach
        public string Name { get; set; }

        //Nam xuat ban
        public string PublicYear { get; set; }
        //Nha xuat ban
        public string PublicCompany { get; set; }

        //Ma loai
        public int CategoryId { get; set; }
        //Ma nha cung cap
        public int SupplierId { get; set; }
        //gia
        public decimal Price { get; set; }
        //So luong
        //public int Quantity { get; set; }
        public BookResponse(Book book)
        {
            BookId = book.BookId;
            Name = book.Name;
            PublicYear = book.PublicYear;
            PublicCompany = book.PublicCompany;
            CategoryId = book.CategoryId;
            SupplierId = book.SupplierId;
            Price = book.Price;
            // Quantity = book.Quantity;

        }

    }
}