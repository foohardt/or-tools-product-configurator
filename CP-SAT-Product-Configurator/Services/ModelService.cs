using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class ModelService
    {
        private readonly IMongoCollection<Model> _models;
        
        public ModelService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _models = database.GetCollection<Model>("Models");
        }

        public List<Model> Get()
        {
            return _models.Find(model => true).ToList();
        }

        public Model Get(string id)
        {
            return _models.Find<Model>(model => model._Id == id).FirstOrDefault();
        }

        public Model Create(Model model)
        {
            _models.InsertOne(model);
            return model;
        }

        public void Update(string id, Model modelIn)
        {
            _models.ReplaceOne(model => model._Id == id, modelIn);
        }

        public void Remove(Model modelIn)
        {
            _models.DeleteOne(model => model._Id == modelIn._Id);
        }

        public void Remove(string id)
        {
            _models.DeleteOne(model => model._Id == id);
        }
    }
}