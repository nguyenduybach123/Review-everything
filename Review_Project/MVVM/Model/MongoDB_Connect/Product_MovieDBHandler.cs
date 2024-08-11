using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Product_MovieDBHandler
    {
        IMongoCollection<Product_Movie> collection;
        public Product_MovieDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Product_Movie>("product_Movie");
        }

        public async Task<Product_Movie> GetProductToIDAsync(string ID)
        {
            var filter = Builders<Product_Movie>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<Product_Movie> GetProductByNameAsync(string name)
        {
            var filter = Builders<Product_Movie>.Filter.Where(p => p.Name == name);
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<UpdateResult> UpdateOneProductSoldAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Movie> filter = Builders<Product_Movie>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Movie> updateDefinition = Builders<Product_Movie>.Update.Set(p => p.NumberSold, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<UpdateResult> UpdateOneProductReviewAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Movie> filter = Builders<Product_Movie>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Movie> updateDefinition = Builders<Product_Movie>.Update.Set(p => p.NumberReview, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<bool> InsertOneProductAsync(Product_Movie product)
        {
            try
            {
                collection.InsertOne(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
