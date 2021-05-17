using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace DotnetApiMongoDB.Data.Collections
{
    public class Infected
    {
        public DateTime bornData {get; set;}
        public string gender {get; set;}
        public GeoJson2DGeographicCoordinates localization {get; set;}



        public Infected(DateTime bornData, string gender, double latitude, double longitude )
        {
            this.bornData = bornData;
            this.gender = gender;
            this.localization = new GeoJson2DGeographicCoordinates(longitude,latitude);
        }
        
    }
}