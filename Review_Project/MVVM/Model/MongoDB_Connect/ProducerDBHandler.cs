using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class ProducerDBHandler
    {
        IMongoCollection<Producer> collection;
        public ProducerDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Producer>("producer");
        }

        public async Task<int> CreateUserReviewerAsync(Producer producer)
        {
            try
            {
                var filter = Builders<Producer>.Filter.Eq(r => r.Name, producer.Name);
                var existingProducer = await collection.Find(filter).FirstOrDefaultAsync();

                if (existingProducer != null)
                {
                    return 0;
                }

                collection.InsertOne(producer);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

        public async Task<Producer> GetUserProducerAsync(string userID)
        {
            var filter = Builders<Producer>.Filter.Eq("_id", ObjectId.Parse(userID));
            return collection.Find(filter).FirstOrDefault();
        }
    }
}
