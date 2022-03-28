using AutoMapper;
using WebProgrammingBackEnd.DTOs;
using WebProgrammingBackEnd.Entities;

namespace WebProgrammingBackEnd.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Category, CategoryLoadDTO>();
            CreateMap<Product, ProductLoadDTO>();
            CreateMap<ProductRegisterDTO, Product>()
                .ForMember(dest => dest.Categories, act => act.Ignore());
            CreateMap<ProductEditDTO, Product>()
                .ForMember(dest => dest.Categories, act => act.Ignore());
            CreateMap<CategoryRegisterDTO, Category>();
            CreateMap<CategoryEditDTO, Category>();
            CreateMap<OrderRegisterDTO,Order>()
            .ForMember(dest => dest.SubOrders, act => act.Ignore());
            CreateMap<OrderEditDTO, Order>();
            CreateMap<Order,OrderLoadDTO>();
            CreateMap<SubOrder,SubOrderLoadDTO>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<User, UserLoadDTO>();
            CreateMap<UserEditDTO, User>();
            CreateMap<Role, string>().ConvertUsing(x => x.Name);
            CreateMap<Image, int>().ConvertUsing(x => x.Id);
        }
    }
}
