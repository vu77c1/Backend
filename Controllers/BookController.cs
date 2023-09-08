using Microsoft.AspNetCore.Mvc;
using MSQL.Models.BookModel;
using MSQL.Service;

namespace MSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_bookRepository.GetAll());
        }
        [HttpPost]
        public BookResponse Add(BookRequestAdd request)
        {
            return _bookRepository.Add(request);

        }
        [HttpPut]
        public void Update(BookRequestEdit bookRequestEdit)
        {
            _bookRepository.Update(bookRequestEdit);
        }
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
        [HttpGet]
        [Route("{id}")]
        public BookResponse GetById(int id)
        {
            return _bookRepository.GetById(id);


        }

    }
}