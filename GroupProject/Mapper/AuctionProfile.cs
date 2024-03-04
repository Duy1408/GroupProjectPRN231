using AutoMapper;
using BusinessObject.BusinessObject;
using BusinessObject.DTO.Request;
using BusinessObject.DTO.Response;

namespace GroupProject.Mapper
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            CreateMap<AuctionCreateDTO, Auction>()

            .ForMember(
                dest => dest.DateStart,
                opt => opt.MapFrom(src => src.DateStart)
            )
            .ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.DateEnd)
            )
            .ForMember(
                dest => dest.AuctionType,
                opt => opt.MapFrom(src => src.AuctionType)
            ).ForMember(
                dest => dest.DepositeAmount,
                opt => opt.MapFrom(src => src.DepositeAmount)
            )
            .ForMember(
                dest => dest.FeeAmount,
                opt => opt.MapFrom(src => src.FeeAmount)
            )
            .ForMember(
                dest => dest.BidID,
                opt => opt.MapFrom(src => src.BidID)
            )
             .ForMember(
                dest => dest.RealEstateID,
                opt => opt.MapFrom(src => src.RealEstateID)
            );


            CreateMap<AuctionUpdateDTO, Auction>()

            .ForMember(
                dest => dest.DateStart,
                opt => opt.MapFrom(src => src.DateStart)
            )
            .ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.DateEnd)
            )
            .ForMember(
                dest => dest.AuctionType,
                opt => opt.MapFrom(src => src.AuctionType)
            ).ForMember(
                dest => dest.DepositeAmount,
                opt => opt.MapFrom(src => src.DepositeAmount)
            )
            .ForMember(
                dest => dest.FeeAmount,
                opt => opt.MapFrom(src => src.FeeAmount)
            )
            .ForMember(
                dest => dest.BidID,
                opt => opt.MapFrom(src => src.BidID)
            )
             .ForMember(
                dest => dest.RealEstateID,
                opt => opt.MapFrom(src => src.RealEstateID)
            );

            CreateMap<AuctionResponseDTO, Auction>()
        .ForMember(
            dest => dest.AuctionID,
            opt => opt.MapFrom(src => src.AuctionID)
        )
        .ForMember(
            dest => dest.DateStart,
            opt => opt.MapFrom(src => src.DateStart)
        )
        .ForMember(
            dest => dest.DateEnd,
            opt => opt.MapFrom(src => src.DateEnd)
        )
        .ForMember(
            dest => dest.AuctionType,
            opt => opt.MapFrom(src => src.AuctionType)
        ).ForMember(
            dest => dest.DepositeAmount,
            opt => opt.MapFrom(src => src.DepositeAmount)
        )
        .ForMember(
            dest => dest.FeeAmount,
            opt => opt.MapFrom(src => src.FeeAmount)
        )
        .ForMember(
            dest => dest.BidID,
            opt => opt.MapFrom(src => src.BidID)
        )
         .ForMember(
            dest => dest.RealEstateID,
            opt => opt.MapFrom(src => src.RealEstateID)
        );




        }
    }
}
