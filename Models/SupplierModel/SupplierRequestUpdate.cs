namespace MSQL.Models.SupplierModel
{
    public class SupplierRequestUpdate
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}