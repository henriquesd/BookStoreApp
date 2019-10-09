# BookStoreApp


### AutoMapper (BookStoreApp.API)
```
Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection
```

### BookStoreApp.Infrastructure
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Relational
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```


-----------------------------------------------------


## Entity Framework Commands

### Create Migrations
```
dotnet ef migrations add Initial
```

### Generate Scripts
```
Script-Migration -Context BookStoreAppContext
```

### Create and update database
```
dotnet ef database update
```

### On Infrastructure project:
- dotnet ef migrations add inform_migration_name --startup-project ..\BookStoreApp.API\
- dotnet ef database update --startup-project ..\BookStoreApp.API\
