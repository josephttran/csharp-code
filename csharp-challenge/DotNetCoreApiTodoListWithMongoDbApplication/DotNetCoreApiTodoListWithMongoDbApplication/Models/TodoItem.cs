namespace DotNetCoreApiTodoListWithMongoDbApplication.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
