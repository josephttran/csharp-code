using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNetCoreApiTodoListWithMongoDbApplication.Models
{
    [BsonIgnoreExtraElements]
    public class TodoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [BsonElement("isDone")]
        [JsonPropertyName("isDone")]
        public bool IsDone { get; set; }
    }
}
