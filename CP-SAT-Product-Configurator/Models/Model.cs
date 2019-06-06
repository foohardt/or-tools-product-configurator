using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CP_SAT_Product_Configurator.Models
{
  public class Model
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string ModelName { get; set; }

    [BsonElement("Category")]
    public VehicleCategory VehicleCategory { get; set; }

    [BsonElement("Price")]
    public decimal ModelPrice { get; set; }

    [BsonElement("Features")]
    public BsonArray ModelFeatures { get; set; }
  }
  public enum VehicleCategory
  {
    Compact, Sedan, Suv
  };
}