using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

using WpfApplication.Models;

namespace WpfApplication.DataAccess
{
    public class PeopleRepository : DataConnection
    {
        private readonly IMongoCollection<PersonModel> peopleCollection;

        public PeopleRepository()
        {
            string dbCollectionName = "people";
            peopleCollection = Database.GetCollection<PersonModel>(dbCollectionName);
        }

        public async Task<List<PersonModel>> GetAll()
        {
            return await peopleCollection.Find(new BsonDocument()).ToListAsync();
        }


        public string CreateOrUpdatePerson(PersonModel person)
        {
            var builder = Builders<PersonModel>.Filter;
            var filter = builder.Eq("firstname", person.FirstName) & builder.Eq("lastname", person.LastName);
            var update = Builders<PersonModel>.Update.Set("email", person.Email);

            var result = peopleCollection.Find(filter).FirstOrDefault();

            if (result == null)
            {
                peopleCollection.InsertOne(person);
                return "created";
            }
            else
            {
                peopleCollection.FindOneAndUpdate(filter, update);
                return "updated";
            }
        }

        public bool DeletePerson(PersonModel person)
        {
            var builder = Builders<PersonModel>.Filter;
            var filter = builder.Eq("_id", person.Id);
            var result = peopleCollection.DeleteOne(filter);

            return result.DeletedCount != 0;
        }

        public bool UpdatePerson(PersonModel person)
        {
            var builder = Builders<PersonModel>.Filter;
            var filter = builder.Eq("_id", person.Id);
            var result = peopleCollection.ReplaceOne(filter, person);

            return result.ModifiedCount != 0;
        }
    }
}
