using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bike_Sharing_System.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string MemberId { get; set; }
        public string BikeId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }  // 1 to 5 stars
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}