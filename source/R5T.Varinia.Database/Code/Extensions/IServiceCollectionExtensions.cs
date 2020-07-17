using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.Dacia;


namespace R5T.Varinia.Database
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="LocationRepository{TDbContext}"/> implementation of <see cref="ILocationRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddLocationRepository<TDbContext>(this IServiceCollection services)
            where TDbContext: DbContext, ILocationDbContext
        {
            services.AddSingleton<ILocationRepository, LocationRepository<TDbContext>>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="LocationRepository{TDbContext}"/> implementation of <see cref="ILocationRepository"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ILocationRepository> AddLocationRepositoryAction<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext, ILocationDbContext
        {
            var serviceAction = ServiceAction.New<ILocationRepository>(() => services.AddLocationRepository<TDbContext>());
            return serviceAction;
        }
    }
}
