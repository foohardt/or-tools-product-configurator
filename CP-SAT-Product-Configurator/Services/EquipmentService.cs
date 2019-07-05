using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class EquipmentService
    {
        private readonly IMongoCollection<Equipment> _equipment;

        public EquipmentService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _equipment = database.GetCollection<Equipment>("Equipment");
        }

        public List<Equipment> Get()
        {
            return _equipment.Find(equipment => true).ToList();
        }
    }
}
