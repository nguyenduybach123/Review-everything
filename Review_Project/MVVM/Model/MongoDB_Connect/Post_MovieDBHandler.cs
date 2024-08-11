using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Review_Project.MVVM.Model;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Post_MovieDBHandler
    {
        IMongoCollection<Post_Movie> collection;
        public Post_MovieDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Post_Movie>("reviewer_post_Movie");
        }

        public async Task<Post_Movie> GetPostByIDAsync(string ID)
        {
            var filter = Builders<Post_Movie>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<List<Post_Movie>> GetPostByProductIDAsync(string productID)
        {
            var filter = Builders<Post_Movie>.Filter.Where(p => p.ProductID == productID);
            return collection.Find(filter).ToList();
        }


        public async Task<bool> InsertOnePostAsync(Post_Movie post)
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
