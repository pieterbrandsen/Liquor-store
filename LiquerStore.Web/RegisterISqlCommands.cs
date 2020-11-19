using LiquerStore.DAL.Services.DbCommands;
using Microsoft.Extensions.DependencyInjection;

namespace LiquerStore.Web
{
    public static class MyServices
    {
        public static IServiceCollection RegisterWhiskeyServices(this IServiceCollection services)
        {
            // Add IStorage and storageService to services
            return services
                .AddTransient<IStorage, StorageService>();
        }
    }
}