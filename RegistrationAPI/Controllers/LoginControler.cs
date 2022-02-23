using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;
using RegistrationAPI.Services;

namespace RegistrationAPI.Controllers
{
    [Route("api/login")]
    public class LoginControler : ControllerBase
    {
        private readonly ILoginService _service;
        
        public LoginControler(ILoginService service,UserDbContext dbContext)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Login([FromBody] LoginUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isLogged = _service.Loggin(dto);

            if (!isLogged)
                return NotFound("Bad login or password");

            return Ok();
        }
    }
}