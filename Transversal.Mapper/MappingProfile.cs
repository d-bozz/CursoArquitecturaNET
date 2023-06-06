using AutoMapper;
using Dominio.Entity;
using Application.DTO;

namespace Transversal.Mapper
{
    public class MappingProfile : Profile
    {
       public MappingProfile() 
       { 
            CreateMap<Customers, CustomersDTO>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();

            // En caso de tener que mappear campo por campo porque los objetos nos coinciden
            // se hace de la siguiente manera: 
            //CreateMap<Customers, CustomerDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();

        }
    }
}