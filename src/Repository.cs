using System.Collections.Generic;
using System.Linq;
using Minify.Interfaces;
using Minify.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Minify
{
    public class Repository : IRepository
    {
        public static List<MinifyData> collection = new List<MinifyData>();
        
        
        public void Add(MinifyData minifyData)
        {
            minifyData.Key = new TokenGenerator().Generate();
            collection.Add(minifyData);
        }

        public void Delete(string key)
        {
            collection.Remove(this.Get(key));
        }

        public IEnumerable<MinifyData> Get()
        {
            return collection;
        }
        
        public MinifyData Get(string key)
        {
            var data = collection.FirstOrDefault(data => data.Key == key);
            return data;
        }
    }
}