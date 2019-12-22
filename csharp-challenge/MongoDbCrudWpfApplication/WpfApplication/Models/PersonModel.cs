using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WpfApplication.Models
{
    public class PersonModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("firstname")]
        public string FirstName { get; set; }

        [BsonElement("lastname")]
        public string LastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
