using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class GearService
    {
        private readonly IMongoCollection<Gear> _gears;

        public GearService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _gears = database.GetCollection<Gear>("Gears");
        }

        public List<Gear> Get()
        {
            return _gears.Find(gear => true).ToList();
        }
    }
}
