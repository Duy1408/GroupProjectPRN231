using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO;
using BusinessObject.ViewModels;
using System.Security.Principal;

namespace GroupProject.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();


        }
    }
}
