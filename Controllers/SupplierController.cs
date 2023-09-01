using Microsoft.AspNetCore.Mvc;
using MSQL.Models;
using MSQL.Models.SupplierModel;
using MSQL.Service;

namespace MSQL.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ISupplierRepository _supplierRepository;
    public SupplierController(ISupplierRepository supplierRepository)
    {
        this._supplierRepository = supplierRepository;
    }
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_supplierRepository.GetAll());
    }
    [HttpPost]
    public SupplierResponse Add(SupplierRequestAdd request)
    {
        return _supplierRepository.Add(request);

    }
    [HttpPut]
    public void Update(SupplierRequestUpdate supplierRequestUpdate)
    {
        _supplierRepository.Update(supplierRequestUpdate);
    }
    [HttpDelete]
    [Route("{id}")]
    public void Delete(int id)
    {
        _supplierRepository.Delete(id);
    }
    [HttpGet]
    [Route("{id}")]
    public SupplierResponse GetById(int id)
    {
        return _supplierRepository.GetById(id);


    }

}
