## .NET Core Command line

| Options | Description |
| ------ | ------ |
| -n, --name | The name for the output being created. If no name is specified, the name of the current directory is used. |
| -o, --output | Location to place the generated output. |

#### Create projects using command lines

1. Create solution using command line with the name mySolutionName

```dotnet new sln -n mySolutionName```

2. Create a new razor page project in myWebAppName folder

```dotnet new webapp -o myWebAppName```

3. Associate project with solution

```dotnet sln mySolutionName.sln add myWebAppName```

4. Create new class library project in classLibraryName folder

```dotnet new classlib -o classLibraryName```

5. Add reference of the class library to project and solution

```dotnet sln add myLib```
```dotnet add myWebAppName reference myLib```