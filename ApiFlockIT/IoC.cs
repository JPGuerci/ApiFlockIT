
using ApiFlockIT.Services;
using Microsoft.Extensions.DependencyInjection;
using NetCoreApi.Services;
using WebApiNet.Services;

namespace WebApiNet
{
    public static class IoC
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<ICoordenadasAPI, CoordenadasAPI>();
            services.AddTransient<IUserValidate, UserValidate>();
            services.AddSingleton<Ilog4netManager, log4netManager>();
        }
        
    }
}
