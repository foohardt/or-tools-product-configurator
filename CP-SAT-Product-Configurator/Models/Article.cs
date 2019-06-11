using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CP_SAT_Product_Configurator.Models
{
    public class Article
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string articleName { get; set; }

        [BsonElement("Category")]
        public string category { get; set; }

        [BsonElement("Price")]
        public decimal price { get; set;}

        [BsonElement("Constraints")]
        public BsonArray constraints { get; set; }
    }
}