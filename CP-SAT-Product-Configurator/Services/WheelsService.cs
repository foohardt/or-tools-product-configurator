using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class WheelsService
    {
        private readonly IMongoCollection<Wheels> _wheels;

        public WheelsService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _wheels = database.GetCollection<Wheels>("Wheels");
        }

        public List<Wheels> Get()
        {
            return _wheels.Find(wheels => true).ToList();
        }
    }
}
