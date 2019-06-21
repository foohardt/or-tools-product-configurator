using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class EngineService
    {
        private readonly IMongoCollection<Engine> _engines;

        public EngineService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _engines = database.GetCollection<Engine>("Engines");
        }

        public List<Engine> Get()
        {
            return _engines.Find(engine => true).ToList();
        }
    }
}
