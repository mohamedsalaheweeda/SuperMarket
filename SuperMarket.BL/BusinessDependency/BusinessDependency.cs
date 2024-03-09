using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public static class BusinessDependency
    {
        public static IServiceCollection BusinessDependencyServices(this IServiceCollection services)
        {
            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGenricService<ReadUserDto>, UserService>();
            services.AddScoped<IGenricServiceAdd<AddUserDto>, UserService>();
            services.AddScoped<IGenricService<ReadBrandDto>, BrandService>();
            services.AddScoped<IGenricServiceAdd<AddBrandDto>, BrandService>();
            services.AddScoped<IGenricService<ReadCategoryDto>, CatagoreyService>();
            services.AddScoped<IGenricServiceAdd<AddCategoryDto>, CatagoreyService>();
            services.AddScoped<IGenricService<ReadCustomerDto>, CustomerService>();
            services.AddScoped<IGenricServiceAdd<AddCustomerDto>, CustomerService>();
            services.AddScoped<IGenricService<ReadOrderDto>, OrderService>();
            services.AddScoped<IGenricServiceAdd<AddOrderDto>, OrderService>();
            services.AddScoped<IGenricService<ReadPaymentDto>, PaymentService>();
            services.AddScoped<IGenricServiceAdd<AddPaymentDto>, PaymentService>();
            services.AddScoped<IGenricService<ReadProductDto>, ProductService>();
            services.AddScoped<IGenricServiceAdd<AddProductDto>, ProductService>();
            services.AddScoped<IGenricService<ReadProductWithOrderDto>, ProductWithOrderService>();
            services.AddScoped<IGenricServiceAdd<AddProductWithOrderDto>, ProductWithOrderService>();
            services.AddScoped<IGenricService<ReadReviewDto>, ReviewService>();
            services.AddScoped<IGenricServiceAdd<AddReviewDto>, ReviewService>();
            services.AddScoped<IGenricService<ReadStockDto>, StockService>();
            services.AddScoped<IGenricServiceAdd<AddStockDto>, StockService>();


            


            return services;
        }
    }
}
