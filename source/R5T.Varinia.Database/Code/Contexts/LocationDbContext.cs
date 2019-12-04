using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Varinia.Database
{
    public class LocationDbContext : DbContext
    {
        public DbSet<Entities.Location> Locations { get; set; }


        public LocationDbContext(DbContextOptions<LocationDbContext> options)
               : base(options)
        {
        }
    }
}
