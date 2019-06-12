using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CP_SAT_Product_Configurator.Models
{
    public class Model
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string code { get; set; }

        [BsonElement("modelName")]
        public string ModelName { get; set; }

        [BsonElement("modelType")]
        public ModelCategory ModelCategory { get; set; }

        [BsonElement("modelEngineType")]
        public ModelEngine ModelEngineType { get; set; }

        [BsonElement("basePrice")]
        public decimal ModelPrice { get; set; }

        [BsonElement("Features")]
        public BsonArray ModelFeatures { get; set; }

        [BsonElement("description")]
        public string description { get; set; }
    }
    public enum ModelCategory
    {
        Compact = 1, Sedan = 2, SUV = 3, FourWD = 4, Sportscar = 5, Van = 6, Mini = 7, Truck = 8
    };

    public enum ModelEngine
    {
        Diesel = 1, Otto = 2, Elektro = 3, Hybrid = 4
    };
}