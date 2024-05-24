# MVC-grade-app

```yml

docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=someThingComplicated1234' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
```

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=mvc-app;User Id=sa;Password=someThingComplicated1234;TrustServerCertificate=True;MultiSubnetFailover=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```