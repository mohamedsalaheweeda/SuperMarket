using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public static class DataDependency
    {

        public static IServiceCollection DataDependencyServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenricRepository<>), typeof(GenricRepository<>));

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IBrandRepo, BrandRepo>();
            services.AddScoped<ICategoreyRepo, CategoreyRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductWithOrderRepo, ProductWithOrderRepo>();
            services.AddScoped<IReviewRepo, ReviewRepo>();
            services.AddScoped<IStockRepo, StockRepo>();

            return services;
        }
    }
}
