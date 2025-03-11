# Cats Web API

A web API that fetches records from the https://thecatapi.com into a database and then provides endpoints to perform CRUD operations on those imported records.

## API key
Get an API key from https://thecatapi.com/#pricing 

## Database setup

1. Create a new empty Microsoft SQL Server database.
2. Execute script **CreateDBTables.sql** or **efbundle.exe** to create the database objects. Both files are located inside the **Deployment** directory.
3. Edit file appsettings.json:
   * Set your SQL Server and database name in ConnectionStrings section.
   * Copy the acquired API key to api_key field.
    ```
    "cats_api_settings": {
        "api_key": "API_KEY",
        "api_address": "https://api.thecatapi.com"
    },
    "ConnectionStrings": {
        "DefaultConnection": "Server=SERVER_NAME;Database=DB_NAME;Trusted_Connection=True;TrustServerCertificate=True;"
    }

    ```

## API Reference

### Swagger environment
Navigate to /swagger to get detailed documentation about the endpoints and their functionality.


