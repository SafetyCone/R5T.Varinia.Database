using System;


namespace R5T.Varinia.Database.Entities
{
    public class Location
    {
        public int ID { get; set; }
        
        public Guid GUID { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
    }
}
