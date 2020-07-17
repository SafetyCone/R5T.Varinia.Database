using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.Varinia.Database
{
    public interface ILocationDbContext
    {
        DbSet<Entities.Location> Locations { get; } 
    }
}
