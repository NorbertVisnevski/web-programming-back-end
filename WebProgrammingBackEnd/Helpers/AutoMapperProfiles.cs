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
            CreateMap<ProductRegisterDTO, Product>();
            CreateMap<ProductEditDTO, Product>();
            CreateMap<CategoryRegisterDTO, Category>();
            CreateMap<CategoryEditDTO, Category>();
            CreateMap<OrderRegisterDTO,Order>();
            CreateMap<OrderEditDTO, Order>();
            CreateMap<Order,OrderLoadDTO>();
            CreateMap<SubOrder,SubOrderLoadDTO>();
        }
    }
}
