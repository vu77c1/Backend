namespace MSQL.Service;

using MSQL.Data;
using MSQL.Models.SupplierModel;
public interface ISupplierRepository
{
    List<Supplier> GetAll();
    SupplierResponse Add(SupplierRequestAdd request);
    void Update(SupplierRequestUpdate request);
    void Delete(int id);
    public SupplierResponse GetById(int id);

}
