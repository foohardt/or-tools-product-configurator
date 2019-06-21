using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CP_SAT_Product_Configurator.Models
{
    public class Gear
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("type")]
        public string type { get; set; }
    }
}
