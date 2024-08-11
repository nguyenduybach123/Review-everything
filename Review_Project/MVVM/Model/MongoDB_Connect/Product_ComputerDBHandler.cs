using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class Product_ComputerDBHandler
    {
        IMongoCollection<Product_Computer> collection;
        public Product_ComputerDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Product_Computer>("product_Computer");
        }

        public async Task<Product_Computer> GetProductToIDAsync(string ID)
        {
            var filter = Builders<Product_Computer>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<Product_Computer> GetProductByNameAsync(string name)
        {
            var filter = Builders<Product_Computer>.Filter.Where(p => p.Name == name);
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<UpdateResult> UpdateOneProductSoldAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Computer> filter = Builders<Product_Computer>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Computer> updateDefinition = Builders<Product_Computer>.Update.Set(p => p.NumberSold, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<UpdateResult> UpdateOneProductReviewAsync(string productID, int updateValue)
        {
            FilterDefinition<Product_Computer> filter = Builders<Product_Computer>.Filter.Eq("_id", ObjectId.Parse(productID));
            UpdateDefinition<Product_Computer> updateDefinition = Builders<Product_Computer>.Update.Set(p => p.NumberReview, updateValue);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<bool> InsertOneProductAsync(Product_Computer product)
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
