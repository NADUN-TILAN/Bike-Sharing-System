using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Bike_Sharing_System.Models
{
    public class Member
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PreferredLocation { get; set; }
        public bool IsOfferingBike { get; set; }
        public List<string> RentalHistory { get; set; }
    }
}