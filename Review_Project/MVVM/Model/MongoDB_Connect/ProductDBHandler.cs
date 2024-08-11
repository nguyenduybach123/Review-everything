using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class ProductDBHandler
    {
        public enum TYPE
        {
            Game,
            Computer,
            Movie
        }


        IMongoCollection<Product> collection;
        public ProductDBHandler(TYPE productType){
            MongoDBProvider db = new MongoDBProvider("social_review");
            if (productType == TYPE.Game)
            {
                collection = db.GetCollection<Product>("product_Game");
            }
            else if (productType == TYPE.Computer)
            {
                collection = db.GetCollection<Product>("product_Computer");
            }
            else if (productType == TYPE.Movie) {
                collection = db.GetCollection<Product>("product_Movie");
            }
            else {
                collection = db.GetCollection<Product>("productGame");
            }
        }

        public async Task<Product> GetProductToIDAsync(string ID)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Id == ObjectId.Parse(ID));
            return collection.Find(filter).FirstOrDefault();
        }

    }
}
