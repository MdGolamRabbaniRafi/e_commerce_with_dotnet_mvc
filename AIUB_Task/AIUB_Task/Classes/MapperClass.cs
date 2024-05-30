using AIUB_Task.BLL.DTOs;
using AIUB_Task.DAL.EF;
using AIUB_Task.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIUB_Task.Classes
{
    public class MapperClass
    {
        public static IMapper MappedUser(SignupDTO signupDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<SignupDTO, User>();

                c.CreateMap<User, SignupDTO>();

                c.CreateMap<User, SignupDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }

        public static IMapper MappedCategory(CategoryDTO category)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CategoryDTO, Category>();

                c.CreateMap<Category, CategoryDTO>();

                c.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedCupon(CuponDTO cuponDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CuponDTO, Cupon>();

                c.CreateMap<Cupon, CuponDTO>();

                c.CreateMap<Cupon, CuponDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedaCupon(Cupon cupon)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CuponDTO, Cupon>();

                c.CreateMap<Cupon, CuponDTO>();

                c.CreateMap<Cupon, CuponDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedOrder(OrderDTO orderDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDTO, Order>();

                c.CreateMap<Order, OrderDTO>();

                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedProduct(ProductDTO product)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();

                c.CreateMap<Product, ProductDTO>();

                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedProduct(Product product)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();

                c.CreateMap<Product, ProductDTO>();

                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }

    }
}