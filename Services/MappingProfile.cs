using BusinessObject.Models.DTO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;
using BusinessObject.DTOs;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserLoginDTO, User>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<CartItemCreateDTO, CartItem>().ReverseMap();
            CreateMap<CartItemUpdateDTO, CartItem>().ReverseMap();
            CreateMap<CartDTO, Cart>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();
            CreateMap<OrderItemCreateDTO, OrderItem>().ReverseMap();
            CreateMap<OrderItemUpdateDTO, OrderItem>().ReverseMap();
            CreateMap<PaymentDetailDTO, PaymentDetail>().ReverseMap();
        }
    }
}
