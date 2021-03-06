﻿using LiquerStore.DAL.Services.DbCommands;
using Microsoft.Extensions.DependencyInjection;

namespace LiquerStore.Web
{
    public static class MyServices
    {
        public static IServiceCollection RegisterWhiskeyServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IStorage, StorageService>()
                .AddTransient<IOrder, OrderService>()
                .AddTransient<IUser, UserService>();
        }
    }
}