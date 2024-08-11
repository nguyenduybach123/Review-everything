using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Product_GameDBHandler
    {
        IMongoCollection<Product_Game> collection;
        public Product_GameDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Product_Game>("product_Game");
        }

        public async Task<Product_Game> GetProductToIDAsync(string ID)
        {
            var filter = Builders<Product_Game>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<Product_Game> GetProductByNameAsync(string name)
        {
            var filter = Builders<Product_Game>.Filter.Where(p => p.Name == name);
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<UpdateResult> UpdateOneProductSoldAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Game> filter = Builders<Product_Game>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Game> updateDefinition = Builders<Product_Game>.Update.Set(p => p.NumberSold, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<UpdateResult> UpdateOneProductReviewAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Game> filter = Builders<Product_Game>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Game> updateDefinition = Builders<Product_Game>.Update.Set(p => p.NumberReview, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<bool> InsertOneProductAsync(Product_Game product)
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
