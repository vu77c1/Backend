using MSQL.Data;
using MSQL.Models.BookModel;
namespace MSQL.Service
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        BookResponse Add(BookRequestAdd request);
        void Update(BookRequestEdit request);
        void Delete(int id);
        public BookResponse GetById(int id);

    }
}