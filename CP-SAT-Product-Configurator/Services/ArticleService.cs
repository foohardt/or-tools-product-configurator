using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CP_SAT_Product_Configurator.Models;

namespace CP_SAT_Product_Configurator.Services
{
    public class ArticleService
    {
        private readonly IMongoCollection<Article> _articles;
        
        public ArticleService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ConfiguratorDb"));
            var database = client.GetDatabase("ConfiguratorDb");
            _articles = database.GetCollection<Article>("Articles");
        }

        public List<Article> Get()
        {
            return _articles.Find(article => true).ToList();
        }

        public Article Get(string id)
        {
            return _articles.Find<Article>(article => article.Id == id).FirstOrDefault();
        }

        public Article Create(Article article)
        {
            _articles.InsertOne(article);
            return article;
        }

        public void Update(string id, Article articleIn)
        {
            _articles.ReplaceOne(article => article.Id == id, articleIn);
        }

        public void Remove(Article articleIn)
        {
            _articles.DeleteOne(article => article.Id == articleIn.Id);
        }

        public void Remove(string id)
        {
            _articles.DeleteOne(article => article.Id == id);
        }
    }
}