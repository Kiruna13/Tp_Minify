using System;
using System.Collections.Generic;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Minify{
    public class MongoRepository : IRepository
    {
        [BsonId]
        private IMongoDatabase database;
        public MongoRepository(){
            var client = new MongoClient(
                                "mongodb+srv://EpsiEleve:TvxreYSXYCg89lz1@cluster0-b8srw.azure.mongodb.net/test?retryWrites=true&w=majority"
                            );
            database = client.GetDatabase("Epsi");
        }
        public void Add(MinifyData minifyData)
        {
            database.GetCollection<MinifyData>("thomas")
                .InsertOne(minifyData);
        }
        
        public void Delete(string key)
        {
            database.GetCollection<MinifyData>("thomas")
                .DeleteOne(data => data.Key == key);
        }

        public IEnumerable<MinifyData> Get()
        {
            var documents = database.GetCollection<MinifyData>("thomas").Find(new BsonDocument()).ToList();
            return documents;
        }

        public MinifyData Get(string key)
        {
            var allQueries = database.GetCollection<MinifyData>("thomas").Find(key).FirstOrDefault();
            return allQueries;
        }
    }
}