using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class VehicleModelService
    {
        private readonly IMongoCollection<VehicleModel> _vehiclemodels;
        
        public VehicleModelService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("dbname"));
            var database = client.GetDatabase("dbname");
            _vehiclemodels = database.GetCollection<VehicleModel>("VehicleModels");
        }

        public List<VehicleModel> Get()
        {
            return _vehiclemodels.Find(vehiclemodel => true).ToList();
        }

        public VehicleModel Get(string id)
        {
            return _vehiclemodels.Find<VehicleModel>(vehiclemodel => vehiclemodel.Id == id).FirstOrDefault();
        }

        public VehicleModel Create(VehicleModel vehiclemodel)
        {
            _vehiclemodels.InsertOne(vehiclemodel);
            return vehiclemodel;
        }

        public void Update(string id, VehicleModel modelIn)
        {
            _vehiclemodels.ReplaceOne(vehiclemodel => vehiclemodel.Id == id, modelIn);
        }

        public void Remove(VehicleModel modelIn)
        {
            _vehiclemodels.DeleteOne(vehiclemodel => vehiclemodel.Id == modelIn.Id);
        }

        public void Remove(string id)
        {
            _vehiclemodels.DeleteOne(vehiclemodel => vehiclemodel.Id == id);
        }
    }
}