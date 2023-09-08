using MSQL.Data;
using MSQL.Models.BookImportModel;
using MSQL.Models.BookModel;
namespace MSQL.Service
{
    public interface IBookImportRepository
    {
        List<BookImport> GetAll();
        BookImportResponse Add(BookImportRequestAdd request);
        void Update(BookImportRequestEdit request);
        void Delete(int id);
        public BookImportResponse GetById(int id);

    }
}