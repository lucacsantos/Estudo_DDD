using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Service.Validators;

namespace Modelo.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseService;

        public UserController(IBaseService<User> baseService)
        {
            _baseService = baseService;
        }
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Add<UserValidator>(user).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseService.Update<UserValidator>(user));
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseService.Delete(id);
                return true;
            });

            return new NoContentResult();

        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Execute(() => _baseService.Get());
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }

    }
}