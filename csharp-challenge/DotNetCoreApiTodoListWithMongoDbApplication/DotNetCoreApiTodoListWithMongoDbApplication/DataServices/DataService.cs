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

        public async Task<bool> Create(TodoItem todoItem)
        {
            if (todoItem.Id != null)
            {
                var found = await _todosCollection.Find(document => document.Id == todoItem.Id).FirstOrDefaultAsync();

                if (found != null)
                {
                    return false;
                }
            }

            await _todosCollection.InsertOneAsync(todoItem);

            return true;
        }

        public async Task<bool> Complete(string id, TodoItem todoItem)
        {
            ReplaceOneResult replaceOneResult =  await _todosCollection.ReplaceOneAsync(document => document.Id == id, todoItem);

            return replaceOneResult.ModifiedCount != 0;
        }

        public async Task<bool> Update(string id, TodoItem todoItem)
        {
            var filter = Builders<TodoItem>.Filter.Eq(document => document.Id, id);
            var updateDefinition = Builders<TodoItem>.Update.Set(document => document.IsDone, todoItem.IsDone);

            if (!string.IsNullOrWhiteSpace(todoItem.Name))
            {
                updateDefinition = updateDefinition.Set(document => document.Name, todoItem.Name);
            }

            UpdateResult updateResult = await _todosCollection.UpdateOneAsync(filter, updateDefinition);

            return updateResult.ModifiedCount != 0;
        }

        public async Task<bool> Delete(string id)
        {
            DeleteResult deleteResult = await _todosCollection.DeleteOneAsync(todoItem => todoItem.Id == id);

            return deleteResult.DeletedCount != 0;
        }
    }
}
