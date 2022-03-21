﻿using BasicsForExperts.Web.Services;

namespace BasicsForExperts.Web.Extensions
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<WaffleIngredientService>();
            services.AddSingleton<IWaffleCreationService, WaffleCreationService>();

            // Add mutliple implementations
            services.AddSingleton<IWaffleCreationService, AnotherWaffleCreationService>();

            return services;
        }
    }
}
