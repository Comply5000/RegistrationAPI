using AutoMapper;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;

namespace RegistrationAPI.Services
{
    public interface IRegisterService
    {
        int Add(AddUserDto dto);
    }

    public class RegisterService : IRegisterService
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public RegisterService(UserDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Add(AddUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}