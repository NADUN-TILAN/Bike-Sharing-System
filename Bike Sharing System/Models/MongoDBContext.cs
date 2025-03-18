using Bike_Sharing_System.Models;
using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IOptions<DatabaseSettings> settings)
    {
        //var client = new MongoClient(settings.Value.ConnectionString);
        //_database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}
