using _HACore.Logs.Implements;
using _HACore.Logs.Interfaces;
using _HACore.Logs.Models;
using BLL.Services.Implementations;
using BLL.Services.Interfaces;

namespace GGStore.MIddlewares
{
    public class DependencyConfig
    {
        public static void RegisterDependency(IServiceCollection services)
        {
            //BLL.Extensions.ServiceCollectionExtensions.AddBussinessLogicLayer(services, null);
            DAL.Extensions.ServiceCollectionExtensions.AddDataAccessLayer(services, null);

            //Services
            services.AddScoped<IProductService, ProductService>();

            //Logs
            services.AddSingleton<HACoreILogger>(provider =>
            {
                HACOreLoggerFactory.Initialize(new HACoreLoggingConfig());
                return HACOreLoggerFactory.Instance;
            });
        }
    }
}
