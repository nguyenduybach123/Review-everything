using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class ReviewerDBHandler
    {
        IMongoCollection<Reviewer> collection;
        public ReviewerDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<Reviewer>("reviewer");
        }

        public async Task<int> CreateUserReviewerAsync(Reviewer reviewer)
        {
            try
            {
                var filter = Builders<Reviewer>.Filter.Eq(r => r.Name, reviewer.Name);
                var existingReviewer = await collection.Find(filter).FirstOrDefaultAsync();

                if (existingReviewer != null)
                {
                    return 0;
                }

                collection.InsertOne(reviewer);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }

        public async Task<Reviewer> GetUserReviewerAsync(string userID)
        {
            var filter = Builders<Reviewer>.Filter.Eq("_id", ObjectId.Parse(userID));
            return collection.Find(filter).FirstOrDefault(); 
        }

        public async Task<Reviewer> GetUserReviewerByNameAsync(string userName)
        {
            var filter = Builders<Reviewer>.Filter.Eq("userName", userName);
            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<bool> CheckReviewrProductSoldAsync(string reviewerID , string productID)
        {
            var filterReviewerID = Builders<Reviewer>.Filter.Eq("_id", ObjectId.Parse(reviewerID));
            var filterProductSold = Builders<Reviewer>.Filter.AnyEq(u => u.ProductSold, productID);
            var combinedFilter = Builders<Reviewer>.Filter.And(filterReviewerID, filterProductSold);
            if(collection.Find(combinedFilter).FirstOrDefault() != null)
                return true;
            return false;
        }

        public async Task<UpdateResult> UpdateOneReviewerSoldAsync(ObjectId userID,string productID)
        {
            FilterDefinition<Reviewer> filter = Builders<Reviewer>.Filter.Eq("_id", userID);
            UpdateDefinition<Reviewer> updateDefinition = Builders<Reviewer>.Update.AddToSet(u => u.ProductSold, productID);
            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }
    }
}
