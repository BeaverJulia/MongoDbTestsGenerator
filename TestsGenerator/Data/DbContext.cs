using MongoDB.Driver;

namespace TestsGenerator.Data
{
    public class DbContext
    {
        public static string connectionstring;
        public static IMongoClient client;
        public IMongoDatabase database;
        public DbContext()
        {
            connectionstring = "mongodb://localhost:27017";
            client = new MongoClient(connectionstring);
            database = client.GetDatabase("local");
        }
    }
}