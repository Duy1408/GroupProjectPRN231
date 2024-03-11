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
            CreateMap<UserVM, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();

            CreateMap<BidVM, Bid>().ReverseMap();
            CreateMap<BidDTO, Bid>().ReverseMap();


        }
    }
}
