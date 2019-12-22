using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WpfApplication.Models;

namespace WpfApplication.DataAccess
{
    public class DataConnection
    {
        private readonly string dbName = "csharp";
        protected IMongoDatabase Database { get; set; }

        protected DataConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            MongoClient Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(dbName);
        }
    }
}
