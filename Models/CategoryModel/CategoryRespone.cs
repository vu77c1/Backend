using MSQL.Data;

namespace MSQL.Models.CategoryModel
{
    public class CategoryRespone
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public CategoryRespone(Category c)
        {
            CategoryId = c.CategoryId;
            CategoryName = c.CategoryName;
            Description = c.Description;

        }

    }
}