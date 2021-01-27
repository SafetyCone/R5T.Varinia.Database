using System;

using R5T.Corcyra;

using AppType = R5T.Corcyra.Location;
using EntityType = R5T.Varinia.Database.Entities.Location;


namespace R5T.Varinia.Database
{
    public static class LocationExtensions
    {
        public static AppType ToAppType(this EntityType entityType)
        {
            var appType = new AppType()
            {
                Identity = LocationIdentity.From(entityType.GUID),
                LngLat = new LngLat()
                {
                    Lat = entityType.Latitude.Value,
                    Lng = entityType.Longitude.Value,
                },
            };

            return appType;
        }
    }
}
