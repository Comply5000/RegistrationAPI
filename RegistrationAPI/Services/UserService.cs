using AutoMapper;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;

namespace RegistrationAPI.Services
{
    public interface IUserService
    {
        int Add(AddUserDto dto);
    }

    public class UserService : IUserService
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(UserDbContext dbContext,IMapper mapper)
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