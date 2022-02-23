using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookAPI.Service.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string writerName { get; set; }
        public string publisher { get; set; }
        public string years { get; set; }
    }
}
