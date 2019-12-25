using DotNetCoreApiTodoListWithMongoDbApplication.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreApiTodoListWithMongoDbApplication.DataServices
{
    public class DataService
    {
        private readonly IMongoCollection<TodoItem> _todosCollection;

        public DataService(ITodosDatabaseSettings todosDatabaseSettings)
        {
            MongoClient client = new MongoClient(todosDatabaseSettings.ConnectionStrings);
            IMongoDatabase database = client.GetDatabase(todosDatabaseSettings.DataBaseName);
            _todosCollection = database.GetCollection<TodoItem>(todosDatabaseSettings.CollectionName);
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _todosCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<TodoItem> GetOneById(string id)
        {
            return await _todosCollection.Find(todoItem => todoItem.Id == id).FirstOrDefaultAsync();
        }
    }
}
