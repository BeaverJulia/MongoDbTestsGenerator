using TestsGenerator.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace TestsGenerator.Data
{
    public class DbContext
    {
        public static string connectionstring;
        public static MongoClient client;
        public MongoDatabase database;
        public static MongoServer server;
        public DbContext()
        {
            connectionstring = "mongodb://localhost:27017";
            client = new MongoClient(connectionstring);
            server = client.GetServer();
            database = server.GetDatabase("local");
        }
    }
}