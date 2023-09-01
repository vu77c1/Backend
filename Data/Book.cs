using System.ComponentModel.DataAnnotations;

namespace MSQL.Data;
public class Book
{
    //Ma sach
    [Key]
    public int BookId { get; set; }
    //Ten sach
    public string Name { get; set; }

    //Nam xuat ban
    public string PublicYear { get; set; }
    //Nha xuat ban
    public string PublicCompany { get; set; }

    //Ma loai
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    //Ma nha cung cap
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    //gia
    public decimal Price { get; set; }
    //So luong
    public int Quantity { get; set; }

}
