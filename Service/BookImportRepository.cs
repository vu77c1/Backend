using System.Data;
using MSQL.Data;
using MSQL.Models.BookImportModel;
using MSQL.Models.BookModel;
using MySql.Data.MySqlClient;
using System.Linq;

namespace MSQL.Service
{
    public class BookImportRepository : IBookImportRepository
    {
        private readonly MsqlContext _context;
        private readonly IConfiguration _configuration;
        public BookImportRepository(MsqlContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public BookImportResponse Add(BookImportRequestAdd request)
        {

            /* try
             {
                 string query = @"
                           INSERT INTO `BooksImport`(`CategoryId`, `CategoryName`, `Quantity`, `DateAt`, `Price`) 
                           VALUES ('@CategoryId','@CategoryName','@Quantity','@DateAt','@Price')
                             ";

                 DataTable table = new DataTable();
                 string sqlDataSource = _configuration.GetConnectionString("Default");
                 MySqlDataReader myReader;
                 using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
                 {
                     myCon.Open();
                     using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                     {
                         myCommand.Parameters.AddWithValue("@CategoryId", request.CategoryId);
                         myCommand.Parameters.AddWithValue("@CategoryName", request.CategoryName);
                         myCommand.Parameters.AddWithValue("@Quantity", request.Quantity);
                         myCommand.Parameters.AddWithValue("@DateAt", request.DateAt);
                         myCommand.Parameters.AddWithValue("@Price", request.Price);
                         myReader = myCommand.ExecuteReader();
                         table.Load(myReader);
                         myReader.Close();
                         myCon.Close();
                     }
                 }
             }
             catch (System.Exception)
             {

                 throw new NotImplementedException();
             }*/
            var data = new BookImport()
            {
                CategoryName = request.CategoryName,
                CategoryId = request.CategoryId,
                Quantity = request.Quantity,
                DateAt = DateTime.UtcNow,
                Price = request.Price,
            };
            try
            {
                _context.Add(data);
                _context.SaveChanges();
                return new BookImportResponse(data);
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
                string query = @"
                           delete from BooksImport
                            where BookImportId=@BookImportId
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("Default");
                MySqlDataReader myReader;
                using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@BookImportId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (System.Exception)
            {

                throw new NotImplementedException();
            }

        }

        public List<BookImport> GetAll()
        {
            /* string query = @"
                             select * from
                             BooksImport
                             ";
             List<BookImport> list = new List<BookImport>();

             DataTable table = new DataTable();
             string sqlDataSource = _configuration.GetConnectionString("Default");
             MySqlDataReader myReader;
             using (MySqlConnection myCon = new MySqlConnection(sqlDataSource))
             {
                 myCon.Open();
                 using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                 {
                     myReader = myCommand.ExecuteReader();
                     while (myReader.Read())
                     {
                         list.Add(
                             new BookImport
                             {
                                 BookImportId = Convert.ToInt32(myReader["BookImportId"]),
                                 CategoryId = Convert.ToInt32(myReader["CategoryId"]),
                                 CategoryName = Convert.ToString(myReader["CategoryName"]),
                                 Quantity = Convert.ToInt32(myReader["Quantity"]),
                                 Price = Convert.ToDecimal(myReader["Price"]),
                                 DateAt = Convert.ToDateTime(myReader["DateAt"])


                             }
                         );
                     }
                     myReader.Close();
                     myCon.Close();
                 }
             }
             return list;*/
            try
            {
                var rs = _context.BooksImport.OrderBy(p => p.CategoryId).ToList();
                return rs;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public BookImportResponse GetById(int id)
        {

            throw new NotImplementedException();
        }

        public void Update(BookImportRequestEdit request)
        {
            try
            {
                var rs = _context.BooksImport.FirstOrDefault(x => x.BookImportId == request.BookImportId);
                rs.CategoryName = request.CategoryName;
                rs.CategoryId = request.CategoryId;
                rs.DateAt = DateTime.UtcNow;
                rs.Price = request.Price;
                rs.Quantity = request.Quantity;
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