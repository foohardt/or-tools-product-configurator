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
        public string ArticleName { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set;}

        [BsonElement("Constraints")]
        public BsonArray Constraints { get; set; }
    }
}