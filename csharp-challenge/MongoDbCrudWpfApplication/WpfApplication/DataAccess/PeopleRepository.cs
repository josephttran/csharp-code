using MongoDB.Bson;
using MongoDB.Driver;

using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
