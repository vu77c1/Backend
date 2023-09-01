using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSQL.Models;
using MSQL.Service;
using Newtonsoft.Json;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MSQL.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: /<controller>/
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        // GET: api/values
        //[HttpGet("{page}")]
        [HttpGet]
        public JsonResult GetAll(int page = 1, string sortBy = "", string search = "")
        {
            try
            {
                return new JsonResult(_userRepository.GetAll(page, sortBy, search));

            }
            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPost]
        public JsonResult Create(UserModel u)
        {
            try
            {
                return new JsonResult(_userRepository.Create(u));

            }
            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPut]
        public JsonResult Update(UserModel u)
        {
            try
            {
                return new JsonResult(_userRepository.Update(u));

            }
            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                return new JsonResult(_userRepository.Delete(id));

            }
            catch
            {
                return new JsonResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPost]
        [Route("/api/login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userRepository.Authenticate(model);
            /* Response.Cookies.Append("jwt", response.Token, new CookieOptions
             {
                 HttpOnly = true,
                 IsEssential = true,
                 SameSite = SameSiteMode.None,
                 Secure = true,
                 Expires = DateTime.UtcNow.AddMinutes(1)
             });*/

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [HttpPost]
        [Route("/api/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "Logout success"
            });
        }
    }
}

