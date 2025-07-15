using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBussinessLogicLayer(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            //DAL.Extensions.ServiceCollectionExtensions.AddDataAccessLayer(services, configuration);

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
