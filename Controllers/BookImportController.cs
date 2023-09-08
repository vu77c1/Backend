using Microsoft.AspNetCore.Mvc;
using MSQL.Models.BookImportModel;
using MSQL.Models.BookModel;
using MSQL.Service;

namespace MSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImportController : ControllerBase
    {
        private readonly IBookImportRepository _bookImportRepository;
        public BookImportController(IBookImportRepository bookImportRepository)
        {
            this._bookImportRepository = bookImportRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bookImportRepository.GetAll());
        }
        [HttpPost]
        public BookImportResponse Add(BookImportRequestAdd request)
        {
            return _bookImportRepository.Add(request);

        }
        [HttpPut]
        public void Update(BookImportRequestEdit bookRequestEdit)
        {
            _bookImportRepository.Update(bookRequestEdit);
        }
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _bookImportRepository.Delete(id);
        }
        [HttpGet]
        [Route("{id}")]
        public BookImportResponse GetById(int id)
        {
            return _bookImportRepository.GetById(id);


        }

    }
}