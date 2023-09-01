using System;
using MSQL.Models;

namespace MSQL.Service
{
	public interface ICategoryRepository
	{
        List<CategoryModel> GetAll();
        CategoryViewModel Add(CategoryModel c);
        void Update(CategoryViewModel c);
        void Delete(int id);
    }
}

