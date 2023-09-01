using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MSQL.Common.Rsp;
using MSQL.Models;
using MSQL.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_categoryRepository.GetAll());

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPost]
        public IActionResult Add(CategoryModel c)
        {
            try
            {
               var data= _categoryRepository.Add(c);
                return Ok(data);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPut]
        public IActionResult Update(CategoryViewModel c)
        {

            try
            {
                _categoryRepository.Update(c);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delete([FromBody]int id)
        {
            try
            {
                _categoryRepository.Delete(id);
                return new JsonResult ("delete successfully");
                
            }
            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);

            }

        }
    }
}

