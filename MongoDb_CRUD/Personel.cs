using MongoDB.Bson;

namespace MongoDb_CRUD
{
    public class Personel
    {
        public ObjectId _id { get; set; }
        public string firstname { get; set; }

        public string lastname { get; set; }

        public string[] phones { get; set; }

        public int age { get; set; }

    }
}