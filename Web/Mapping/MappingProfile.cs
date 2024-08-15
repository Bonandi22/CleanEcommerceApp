using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Web.Models;

namespace Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento de User para UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            // Mapeamento de RegisterModel para UserDto
            CreateMap<RegisterModel, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.Customer)); // Define o papel como "Customer" por padrão

            // Mapeamento de UserDto para User
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Ignora o PasswordHash durante o mapeamento
                .ForMember(dest => dest.CartItems, opt => opt.Ignore()); // Ignora a coleção de itens do carrinho, se necessário

            // Outros mapeamentos
            CreateMap<Product, ProductDto>();
            CreateMap<CartItem, CartItemDto>();
        }
    }
}