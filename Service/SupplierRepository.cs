using MSQL.Data;
using MSQL.Models;
using MSQL.Models.SupplierModel;

namespace MSQL.Service;
public class SupplierRepository : ISupplierRepository
{
    private readonly MsqlContext _context;
    public SupplierRepository(MsqlContext context)
    {
        _context = context;

    }

    public SupplierResponse Add(SupplierRequestAdd request)
    {
        var data = new Supplier()
        {
            SupplierName = request.SupplierName,
            Address = request.Address,
            TaxCode = request.TaxCode,
            Email = request.Email,
            Phone = request.Phone

        };
        try
        {
            _context.Add(data);
            _context.SaveChanges();
            return new SupplierResponse(data);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            var sb = _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);

            var i = _context.Remove(sb);
            _context.SaveChanges();

        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public List<Supplier> GetAll()
    {

        try
        {
            return _context.Suppliers.ToList();

        }


        catch (System.Exception)
        {

            throw;
        }



    }

    public SupplierResponse GetById(int id)
    {
        try
        {
            var sb = _context.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            return new SupplierResponse(sb);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void Update(SupplierRequestUpdate request)
    {

        try
        {
            var rs = _context.Suppliers.FirstOrDefault(x => x.SupplierId == request.SupplierId);
            //rs.SupplierId = request.SupplierId;
            rs.SupplierName = request.SupplierName;
            rs.Address = request.Address;
            rs.TaxCode = request.TaxCode;
            rs.Email = request.Email;
            rs.Phone = request.Phone;
            _context.Update(rs);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
