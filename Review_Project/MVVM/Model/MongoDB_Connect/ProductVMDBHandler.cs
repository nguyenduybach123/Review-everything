using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class ProductVMDBHandler
    {
        IMongoCollection<ProductVM> collection;
        public ProductVMDBHandler()
        {
            MongoDBProvider db = new MongoDBProvider("social_review");
            collection = db.GetCollection<ProductVM>("productVM");
        }


        public async Task<IEnumerable<ProductVM>> GetNewProductAsync(int pageSize, int pageStart)
        {
            int startIndex = (pageStart - 1) * pageSize;

            DateTime DaysAgo = DateTime.Now.AddDays(-15);
            var filter = Builders<ProductVM>.Filter.Where(p => p.CreatedAt >= DaysAgo);
            return collection.Find(filter).Skip(startIndex * pageSize).Limit(pageSize).ToList();
        }

        public async Task<IEnumerable<ProductVM>> GetProductForHotAsync(int pageSize, int pageStart, int limitView = 1000)
        {
            int startIndex = (pageStart - 1) * pageSize;

            DateTime DaysAgo = DateTime.Now.AddDays(-15);
            var filterDay = Builders<ProductVM>.Filter.Where(p => p.CreatedAt >= DaysAgo);
            var filterView = Builders<ProductVM>.Filter.Where(p => p.View >= limitView);
            var combinedFilter = Builders<ProductVM>.Filter.And(filterDay, filterView);

            return collection.Find(combinedFilter).Skip(startIndex * pageSize).Limit(pageSize).ToList();
        }

        public async Task<IEnumerable<ProductVM>> GetProductForViewAsync(int pageSize, int pageStart, int limitView = 1000)
        {
            int startIndex = (pageStart - 1) * pageSize;

            var filter = Builders<ProductVM>.Filter.Where(p => p.View >= limitView);
            return collection.Find(filter).Skip(startIndex * pageSize).Limit(pageSize).ToList();
        }


        public async Task<IEnumerable<ProductVM>> GetProductForRankAsync(int pageSize, int pageStart, int limitRank = 10)
        {
            int startIndex = (pageStart - 1) * pageSize;
            int endIndex = startIndex + pageSize - 1;

            var filter = Builders<ProductVM>.Filter.Where(p => p.Rank >= limitRank);
            return collection.Find(filter).Skip(startIndex * pageSize).Limit(pageSize).ToList();
        }

        public async Task<IEnumerable<ProductVM>> GetProductByCategoryAndSearchStringAsync(int head, string categoryID, string searchString)
        {
            if (head == 0)
                return null;


            var filterBuilder = Builders<ProductVM>.Filter;
            if (categoryID == "tất cả")
            {
                if (searchString == "")
                {
                    return collection.Find(x => true).ToList();
                }

                var searchOnlyFilter = filterBuilder.Regex(p => p.Name, new BsonRegularExpression(searchString, "i"));
                return collection.Find(searchOnlyFilter).ToList();
            }
            else if (searchString == "")
            {
                var categoryOnlyFilter = filterBuilder.Eq(p => p.Type.typeId, categoryID);
                return collection.Find(categoryOnlyFilter).ToList();

            }
            else
            {
                var categoryFilter = filterBuilder.Eq(p => p.Type.typeId, categoryID);
                var searchFilter = filterBuilder.Regex(p => p.Name, new BsonRegularExpression(searchString, "i"));
                var combinedFilter = filterBuilder.And(categoryFilter, searchFilter);
                return collection.Find(combinedFilter).ToList();
            }
        }

        public async Task<bool> InsertOneProductVMAsync(ProductVM productVM)
        {
            try
            {
                collection.InsertOne(productVM);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProductVM>> GetProductListByProducerAndCategoryAndProducerIDAsync(string producerID, string categoryID, string searchString)
        {
            var filterBuilder = Builders<ProductVM>.Filter;
            var filterByProducerID = filterBuilder.Eq(p => p.Producer.producerID, producerID);

            if (categoryID == "tất cả")
            {
                if (searchString == "")
                {
                    return collection.Find(filterByProducerID).ToList();
                }

                var searchOnlyFilter = filterBuilder.Regex(p => p.Name, new BsonRegularExpression(searchString, "i"));
                var combinedFilter = filterBuilder.And(searchOnlyFilter, filterByProducerID);
                return collection.Find(combinedFilter).ToList();
            }
            else if (searchString == "")
            {
                var categoryOnlyFilter = filterBuilder.Eq(p => p.Type.typeId, categoryID);
                var combinedFilter = filterBuilder.And(categoryOnlyFilter, filterByProducerID);
                return collection.Find(combinedFilter).ToList();

            }
            else
            {
                var categoryFilter = filterBuilder.Eq(p => p.Type.typeId, categoryID);
                var searchFilter = filterBuilder.Regex(p => p.Name, new BsonRegularExpression(searchString, "i"));
                var combinedFilter = filterBuilder.And(categoryFilter, searchFilter, filterByProducerID);
                return collection.Find(combinedFilter).ToList();
            }
        }

        public async Task<List<ProductVM>> GetProductListByProducerIDAsnyc(string producerID)
        {
            var filterByProducerID = Builders<ProductVM>.Filter.Eq(p => p.Producer.producerID, producerID);
            return collection.Find(filterByProducerID).ToList();
        }

    }
}
