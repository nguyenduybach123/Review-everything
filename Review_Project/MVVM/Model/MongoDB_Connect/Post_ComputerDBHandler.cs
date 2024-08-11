using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Post_ComputerDBHandler
    {
        IMongoCollection<Post_Computer> collection;
        public Post_ComputerDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Post_Computer>("reviewer_post_Computer");
        }

        public async Task<Post_Computer> GetPostByIDAsync(string ID)
        {
            var filter = Builders<Post_Computer>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<List<Post_Computer>> GetPostByProductIDAsync(string productID)
        {
            var filter = Builders<Post_Computer>.Filter.Where(p => p.ProductID == productID);
            return collection.Find(filter).ToList();
        }

        public async Task<bool> InsertOnePostAsync(Post_Computer post)
        {
            try
            {
                collection.InsertOne(post);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
