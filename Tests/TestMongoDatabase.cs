using System;
using System.IO;
using MongoDB.Driver;

namespace Tests
{
    public static class TestMongoDatabase
    {
        public static IMongoDatabase Create()
        {
            string mongoConnectionString;
            using (var reader = new StreamReader("..\\..\\..\\..\\ConsoleApp\\Credentials.txt"))
            {
                mongoConnectionString = reader.ReadLine();
            }

            mongoConnectionString ??= Environment.GetEnvironmentVariable("PROJECT5100_MONGO_CONNECTION_STRING");
            var mongoClient = new MongoClient(mongoConnectionString);
            return mongoClient.GetDatabase("game-tests");
        }
    }
}