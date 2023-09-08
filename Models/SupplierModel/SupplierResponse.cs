using MSQL.Data;

namespace MSQL.Models.SupplierModel;
public class SupplierResponse
{

    public int SupplierId { get; set; }
    public string SupplierName { get; set; }
    public string Address { get; set; }
    public string TaxCode { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public SupplierResponse(Supplier s)
    {
        SupplierId = s.SupplierId;
        SupplierName = s.SupplierName;
        Address = s.Address;
        TaxCode = s.TaxCode;
        Email = s.Email;
        Phone = s.Phone;
    }

}
