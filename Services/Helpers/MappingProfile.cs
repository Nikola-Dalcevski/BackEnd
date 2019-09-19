using DomainModels.Models;
using AutoMapper;
using Models.ViewModels;

namespace BusinessLayer.Helpers
{
    public class MappingProfile : Profile
    {
       
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.Email))
                .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.LastName))
                .ForMember(dest => dest.Phone, src => src.MapFrom(x => x.Phone))
                .ReverseMap()
                .ForMember(dest => dest.Orders, src => src.Ignore())
                .ForMember(dest => dest.Role, src => src.Ignore());

            CreateMap<Bicycle, BicycleViewModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Model, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Brand, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Brakes, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Cassate, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Chain, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Cruncset, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Fork, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Frame, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Handlebar, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Image, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.RearDeraillerur, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.RearHub, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Seat, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.TireInfo, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.TireSize, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Weight, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Prize, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Fullname, src => src.Ignore())
                .ForMember(dest => dest.HasStock, src => src.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Quantity, src => src.Ignore());
                



        }
    }
}
