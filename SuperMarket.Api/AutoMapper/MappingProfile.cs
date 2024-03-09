using AutoMapper;
using SuperMarket.DL;


namespace SuperMarket.BL
{
    public class MapperProfile :  Profile
    {
        public MapperProfile() 
        {
            CreateMap<User, ReadUserDto>().ReverseMap();
            CreateMap<User, AddUserDto>().ReverseMap();
            CreateMap<User , LoginDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<Brand, ReadBrandDto>().ReverseMap();
            CreateMap<Brand, AddBrandDto>().ReverseMap();
            CreateMap<Categorey, ReadCategoryDto>().ReverseMap();
            CreateMap<Categorey, AddCategoryDto>().ReverseMap();
            CreateMap<Customer, ReadCustomerDto>().ReverseMap();
            CreateMap<Customer, AddCustomerDto>().ReverseMap();
            CreateMap<Order, ReadOrderDto>().ReverseMap();
            CreateMap<Order, AddOrderDto>().ReverseMap() ;
            CreateMap<Payment, ReadPaymentDto>().ReverseMap();
            CreateMap<Payment, AddPaymentDto>().ReverseMap();
            CreateMap<Product, ReadProductDto>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap(); 
            CreateMap<ProductWithOrder, ReadProductWithOrderDto>().ReverseMap();
            CreateMap<ProductWithOrder, AddProductWithOrderDto>().ReverseMap(); ;
            CreateMap<Review, ReadReviewDto>().ReverseMap();
            CreateMap<Review, AddReviewDto>().ReverseMap() ;
            CreateMap<Stock, ReadStockDto>().ReverseMap();
            CreateMap<Stock, AddStockDto>().ReverseMap() ;
        }
    }
}
