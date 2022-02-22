using AutoMapper;
using RegistrationAPI.Entities;
using RegistrationAPI.Models;

namespace RegistrationAPI
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserDto, User>()
                .ForMember(r => r.Address,
                    c => c.MapFrom(dto => new Address()
                        {City = dto.City, HouseNumber = dto.HouseNumber, Street = dto.Street}));
        }
    }
}