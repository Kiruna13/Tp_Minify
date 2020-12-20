using MongoDB.Bson.Serialization.Attributes;

namespace Minify.Model{
    public class MinifyData {
        [BsonId]
        public string Key { get; set; }
        public string Url { get; set; }
    }
}