using System.ComponentModel.DataAnnotations;

namespace MSQL.Data;
public class Supplier
{
    [Key]
    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string Address { get; set; }
    public string TaxCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Book> Books { get; set; }

}


