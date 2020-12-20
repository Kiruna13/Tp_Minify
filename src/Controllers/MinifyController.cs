using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Minify.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace Minify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinifyController : ControllerBase
    {
        
        [HttpPost]
        public string Add([FromBody] MinifyData data)
        {
            data = new MinifyData
            {
                
                Key = "",
                Url = "https://www." + data.Url
            };
            new Repository().Add(data);
            new MongoRepository().Add(data);
            return data.Url;
        }

        [HttpGet]
        public IEnumerable<MinifyData> Get()
        {
            return new MongoRepository().Get();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            new Repository().Delete(id);
            new MongoRepository().Delete(id);
        }
    }
}