using Microsoft.EntityFrameworkCore.Internal;
using MSQL.Data;
using MSQL.Models.BookModel;
using Org.BouncyCastle.Crypto.Generators;

namespace MSQL.Service
{
    public class BookRepository : IBookRepository
    {
        private readonly MsqlContext _context;
        public BookRepository(MsqlContext context)
        {
            _context = context;

        }
        public BookResponse Add(BookRequestAdd request)
        {
            var data = new Book()
            {
                Name = request.Name,
                PublicCompany = request.PublicCompany,
                PublicYear = request.PublicYear,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                Price = request.Price,
                // Quantity = request.Quantity
            };
            try
            {
                _context.Add(data);
                _context.SaveChanges();
                return new BookResponse(data);
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
                var sb = _context.Books.FirstOrDefault(x => x.BookId == id);

                var i = _context.Remove(sb);
                _context.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public List<Book> GetAll()
        {
            try
            {


                var sql = (from b in _context.Books
                           join c in _context.BooksImport
                           on b.BookId equals c.CategoryId into bookimport
                           from bi in bookimport.DefaultIfEmpty()
                           select new Book
                           {
                               BookId = b.BookId,
                               Name = b.Name,
                               PublicCompany = b.PublicCompany,
                               PublicYear = b.PublicYear,
                               CategoryId = b.CategoryId,
                               SupplierId = b.SupplierId,
                               Price = b.Price,
                               Quantity = bi.Quantity != null ? bi.Quantity : 0,

                           }).ToList();
                var sum = sql.GroupBy(x => x.BookId).Select(b => new Book
                {
                    BookId = b.First().BookId,
                    Name = b.First().Name,
                    PublicCompany = b.First().PublicCompany,
                    PublicYear = b.First().PublicYear,
                    CategoryId = b.First().CategoryId,
                    SupplierId = b.First().SupplierId,
                    Price = b.First().Price,
                    Quantity = b.Sum(s => s.Quantity)

                }).ToList();
                return sum;



            }


            catch (System.Exception)
            {

                throw;
            }
        }

        public BookResponse GetById(int id)
        {
            try
            {
                var sb = _context.Books.FirstOrDefault(x => x.BookId == id);
                return new BookResponse(sb);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public void Update(BookRequestEdit request)
        {
            try
            {
                var rs = _context.Books.FirstOrDefault(x => x.CategoryId == request.CategoryId);
                rs.Name = request.Name;
                rs.PublicCompany = request.PublicCompany;
                rs.PublicYear = request.PublicYear;
                rs.CategoryId = request.CategoryId;
                rs.SupplierId = request.SupplierId;
                rs.Price = request.Price;
                //  rs.Quantity = rs.Quantity;
                _context.Update(rs);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}