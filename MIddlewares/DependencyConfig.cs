namespace GGStore.MIddlewares
{
    public class DependencyConfig
    {
        public static void RegisterDependency(IServiceCollection services)
        {
            BLL.Extensions.ServiceCollectionExtensions.AddBussinessLogicLayer(services, null);
            DAL.Extensions.ServiceCollectionExtensions.AddDataAccessLayer(services, null);
        }
    }
}
