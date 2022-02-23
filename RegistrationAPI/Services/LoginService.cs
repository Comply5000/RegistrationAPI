using System;
using System.Linq;
using AutoMapper;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;

namespace RegistrationAPI.Services
{
    public interface ILoginService
    {
        bool Loggin(LoginUserDto dto);
    }

    public class LoginService : ILoginService
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginService(UserDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Loggin(LoginUserDto dto)
        {
            foreach (var u in _dbContext.Users)
                if (u.Login == dto.Login && u.Password == dto.Password)
                    return true;

            return false;

        }
        
    }
}