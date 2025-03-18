using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Bike_Sharing_System.Models
{
    public class Bike
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OwnerId { get; set; }
        public string Location { get; set; }
        public string BikeType { get; set; }
        public bool IsAvailable { get; set; }
        public double RentalPrice { get; set; }
        public string BookedBy { get; set; }
    }
}