namespace MSQL.Models.BookModel
{
    public class BookRequestAdd
    {
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
        //   public int Quantity { get; set; }

    }
}