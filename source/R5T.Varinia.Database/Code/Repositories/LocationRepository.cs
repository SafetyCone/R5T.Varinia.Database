using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using R5T.Corcyra;
using R5T.Venetia;


namespace R5T.Varinia.Database
{
    public class LocationRepository<TDbContext> : ProvidedDatabaseRepositoryBase<TDbContext>, ILocationRepository
        where TDbContext: DbContext, ILocationDbContext
    {
        public LocationRepository(DbContextOptions<TDbContext> dbContextOptions, IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextOptions, dbContextProvider)
        {
        }

        public async Task Delete(LocationIdentity identity)
        {
            await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.Locations.Where(x => x.GUID == identity.Value).SingleAsync();

                dbContext.Locations.Remove(entity);

                await dbContext.SaveChangesAsync();
            });
        }

        public async Task<bool> Exists(LocationIdentity identity)
        {
            var exists = await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.Locations.Where(x => x.GUID == identity.Value).SingleOrDefaultAsync();

                var output = entity is object;
                return output;
            });

            return exists;
        }

        public async Task<LngLat> GetLngLat(LocationIdentity identity)
        {
            var lngLat = await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.Locations.Where(x => x.GUID == identity.Value).SingleAsync();

                var output = new LngLat()
                {
                    Lng = entity.Longitude.Value,
                    Lat = entity.Latitude.Value,
                };
                return output;
            });

            return lngLat;
        }

        public async Task<LocationIdentity> New()
        {
            var locationIdentity = LocationIdentity.New();

            await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = new Entities.Location()
                {
                    GUID = locationIdentity.Value,
                };

                dbContext.Locations.Add(entity);

                await dbContext.SaveChangesAsync();
            });

            return locationIdentity;
        }

        public async Task<LocationIdentity> New(LngLat lngLat)
        {
            var locationIdentity = LocationIdentity.New();

            await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = new Entities.Location()
                {
                    GUID = locationIdentity.Value,
                    Longitude = lngLat.Lng,
                    Latitude = lngLat.Lat,
                };

                dbContext.Locations.Add(entity);

                await dbContext.SaveChangesAsync();
            });

            return locationIdentity;
        }

        public async Task SetLngLat(LocationIdentity identity, LngLat lngLat)
        {
            await this.ExecuteInContextAsync(async dbContext =>
            {
                var entity = await dbContext.Locations.Where(x => x.GUID == identity.Value).SingleAsync();

                entity.Longitude = lngLat.Lng;
                entity.Latitude = lngLat.Lat;

                await dbContext.SaveChangesAsync();
            });
        }
    }
}
