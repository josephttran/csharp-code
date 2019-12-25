#### Use User secret manager
right-click the project in Solution Explorer, and select Manage User Secrets.

**secrets.josn**
``` 
{
   "TodosDatabaseSettings:ConnectionStrings": "mongodb://<dbuser>:<dbpassword>@ds042688.mlab.com:42688/csharp/?retryWrites=false",
   "TodosDatabaseSettings:DatabaseName": "csharp",
   "TodosDatabaseSettings:CollectionName": "todos"
}
```

**Dependency injection, Startup.cs**
```
 services.Configure<TodosDatabaseSettings>(Configuration.GetSection(nameof(TodosDatabaseSettings)));
 services.AddSingleton<ITodosDatabaseSettings>(sp => sp.GetRequiredService<IOptions<TodosDatabaseSettings>>().Value);
```
