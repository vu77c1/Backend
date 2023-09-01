using System;
using MSQL.Data;
using MSQL.Models;

namespace MSQL.Service
{
	public class CategoryRepository: ICategoryRepository
    {
        private readonly MsqlContext _context;
        public CategoryRepository(MsqlContext context)
		{
            _context = context;
		}

        public CategoryViewModel Add(CategoryModel c)
        {
            var _c = new Category()
            {
                CategoryName=c.CategoryName,
                Description=c.Description

            };
            _context.Add(_c);
            _context.SaveChanges();
            return new CategoryViewModel()
            {
                CategoryId=_c.CategoryId,
                CategoryName=_c.CategoryName,
                Description=_c.Description

            };
        }

        public List<CategoryModel> GetAll()
        {
            var rs = _context.Categories.Select(c => new CategoryModel()
            {
                CategoryName=c.CategoryName,
                Description=c.Description

            });
            return rs.ToList();
        }
        public void Update( CategoryViewModel c)
        {
            var _c = _context.Categories.SingleOrDefault(p => p.CategoryId == c.CategoryId);
            _c.CategoryName = c.CategoryName;
            _c.Description = c.Description;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
             var _c = _context.Categories.SingleOrDefault(p => p.CategoryId ==id);
            if (_c!=null)
            {
                _context.Remove(_c);
                _context.SaveChanges();
            }

        }
    }
}

