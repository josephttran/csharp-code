using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApiTodoListWithMongoDbApplication.DataServices
{
    public interface ITodosDatabaseSettings
    {
        string ConnectionStrings { get; set; }
        string DataBaseName { get; set; }
        string CollectionName { get; set; }
    }

    public class TodosDatabaseSettings : ITodosDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DataBaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
