using MSQL.Data;
using MSQL.Models.CategoryModel;

namespace MSQL.Service;
public class CategoryRepository : ICategoryRepository
{
    private readonly MsqlContext _context;
    public CategoryRepository(MsqlContext context)
    {
        _context = context;

    }
    public CategoryRespone Add(CategoryRequestAdd request)
    {
        var data = new Category()
        {
            CategoryName = request.CategoryName,
            Description = request.Description,


        };
        try
        {
            _context.Add(data);
            _context.SaveChanges();
            return new CategoryRespone(data);
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
            var sb = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            var i = _context.Remove(sb);
            _context.SaveChanges();

        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public List<Category> GetAll()
    {
        try
        {
            return _context.Categories.ToList();

        }


        catch (System.Exception)
        {

            throw;
        }

    }

    public CategoryRespone GetById(int id)
    {
        try
        {
            var sb = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return new CategoryRespone(sb);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void Update(CategoryRequestEdit request)
    {
        try
        {
            var rs = _context.Categories.FirstOrDefault(x => x.CategoryId == request.CategoryId);
            rs.CategoryName = request.CategoryName;
            rs.Description = request.Description;
            _context.Update(rs);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
