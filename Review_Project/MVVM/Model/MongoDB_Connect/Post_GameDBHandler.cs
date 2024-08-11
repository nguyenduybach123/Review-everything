using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Post_GameDBHandler
    {
        IMongoCollection<Post_Game> collection;
        public Post_GameDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Post_Game>("reviewer_post_Game");
        }

        public async Task<Post_Game> GetPostByIDAsync(string ID)
        {
            var filter = Builders<Post_Game>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<List<Post_Game>> GetPostByProductIDAsync(string productID)
        {
            var filter = Builders<Post_Game>.Filter.Where(p => p.ProductID == productID);
            return collection.Find(filter).ToList();
        }

        public async Task<bool> InsertOnePostAsync(Post_Game post)
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
