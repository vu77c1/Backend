using Microsoft.AspNetCore.Mvc;
using MSQL.Models.CategoryModel;
using MSQL.Service;


namespace MSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_categoryRepository.GetAll());
        }
        [HttpPost]
        public CategoryRespone Add(CategoryRequestAdd request)
        {
            return _categoryRepository.Add(request);

        }
        [HttpPut]
        public void Update(CategoryRequestEdit categoryRequestEdit)
        {
            _categoryRepository.Update(categoryRequestEdit);
        }
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
        [HttpGet]
        [Route("{id}")]
        public CategoryRespone GetById(int id)
        {
            return _categoryRepository.GetById(id);


        }

    }
}