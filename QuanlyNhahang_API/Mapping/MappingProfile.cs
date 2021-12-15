using AutoMapper;
using QuanlyNhahang_API.DTO;
using QuanlyNhahang_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanlyNhahang_API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Role, RoleDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
               .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
               .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
               .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted));
        
            CreateMap<Restaurant, RestaurantDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<Guest, GuestDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<Status, StatusDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.RestaurantDTO, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
                .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<Unit, UnitDTO>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
              .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
              .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
              .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
              .ForMember(dest => dest.UnitType, opt => opt.MapFrom(src => src.UnitType))
              .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
              .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<Category, CategoryDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
              .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
              .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
              .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
              .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
              .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType))
              .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
              .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<ItemImage, ItemImageDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
            .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
            .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
            .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
            .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
            CreateMap<Item, ItemDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
           .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
           .ForMember(dest => dest.Quatity, opt => opt.MapFrom(src => src.Quatity))
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.Deleted, opt => opt.MapFrom(src => src.Deleted))
           .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
           .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
           .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
           .ForMember(dest => dest.ItemImage, opt => opt.MapFrom(src => src.ItemImage))
           .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
           .ForMember(dest => dest.CreatedUser, opt => opt.MapFrom(src => src.CreatedUser))
           .ForMember(dest => dest.UpdatedUser, opt => opt.MapFrom(src => src.UpdatedUser));
        }
    }
}
