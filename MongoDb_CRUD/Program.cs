using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoDb_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertToMongoDb();

            ReadFromMongoDb();

            Console.ReadLine();
        }

        private static void ReadFromMongoDb()
        {
            MongoClient client = GetDbClient();

            IMongoDatabase db = client.GetDatabase("Company");
            var collection = db.GetCollection<Personel>(nameof(Personel));

            var results = collection.Find(x => x.firstname == "Nevzat").ToList();

            Console.WriteLine(results[0].firstname);
        }

        private static void InsertToMongoDb()
        {
            MongoClient client = GetDbClient();

            IMongoDatabase db = client.GetDatabase("Company");
            var collection = db.GetCollection<BsonDocument>("Personel");

            var document = new BsonDocument
            {
              {"firstname", BsonValue.Create("Nevzat")},
              {"lastname", new BsonString("Kaya")},
              { "phones", new BsonArray(new[] {"5056517667", "5038475896"}) },
              { "age", 31 }
            };

            collection.InsertOne(document);
        }

        private static MongoClient GetDbClient()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);
            return client;
        }
    }
}
