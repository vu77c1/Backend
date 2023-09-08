using MSQL.Data;
using MSQL.Models.CategoryModel;

namespace MSQL.Service;
public interface ICategoryRepository
{
    List<Category> GetAll();
    CategoryRespone Add(CategoryRequestAdd request);
    void Update(CategoryRequestEdit request);
    void Delete(int id);
    public CategoryRespone GetById(int id);

}
