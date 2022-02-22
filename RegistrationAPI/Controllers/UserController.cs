using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;
using RegistrationAPI.Services;

namespace RegistrationAPI.Controllers
{
    [Route("api/registration")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly UserDbContext _dbContext;

        public UserController(IUserService service,UserDbContext dbContext)
        {
            _service = service;
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public ActionResult AddUser([FromBody] AddUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (dto.Password != dto.ConfirmedPassword)
                return BadRequest("Bad password");

            var existUser = _dbContext.Users.FirstOrDefault(u => u.Login == dto.Login);
            if(existUser is not null)
                return BadRequest("User with that login exist"); 
            
            var existEmail = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);
            if(existEmail is not null)
                return BadRequest("This email is busy"); 

            var id = _service.Add(dto);

            return Created($"/api/registration/{id}", null);
        }
        
    }
}