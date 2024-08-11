using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Review_Project.MVVM.Model.MongoDB_Connect
{
    public class CommentDBHandler
    {

        public static int itemsPerPage = 5;

        private IMongoCollection<Comment> collection;


        private long documentCount;
        public long DocumentCount
        {
            get { return documentCount; }
        }


        private int limitPage;
        public int LimitPage
        {
            get { return limitPage; }
        }

        public enum TYPE
        {
            Game,
            Computer,
            Movie
        }

        public CommentDBHandler(string commentType)
        {

            TYPE _type = GetProductType(commentType);

            MongoDBProvider db = new MongoDBProvider("social_review");
            if (_type == TYPE.Game)
            {
                collection = db.GetCollection<Comment>("comment_Game");
            }
            else if (_type == TYPE.Computer)
            {
                collection = db.GetCollection<Comment>("comment_Computer");
            }
            else if (_type == TYPE.Movie)
            {
                collection = db.GetCollection<Comment>("comment_Movie");
            }
            else
            {
                collection = db.GetCollection<Comment>("comment_Game");
            }

            var filter = new BsonDocument();
            documentCount = collection.CountDocuments(filter);
            float numberPage = (int)documentCount / (float)itemsPerPage;
            limitPage = (int)Math.Round(numberPage, MidpointRounding.AwayFromZero);
        }

        public long GetCountDocumentByProductID(string productID)
        {
            var filter = Builders<Comment>.Filter.Eq(x => x.ProductID, productID);
            long documentCount = collection.CountDocuments(filter);
            return documentCount;
        }

        public CommentDBHandler.TYPE GetProductType(string CommentType)
        {
            if (CommentType == "Game")
            {
                return CommentDBHandler.TYPE.Game;
            }
            else if (CommentType == "Computer")
            {
                return CommentDBHandler.TYPE.Computer;
            }
            else if (CommentType == "Movie")
            {
                return CommentDBHandler.TYPE.Movie;
            }
            return CommentDBHandler.TYPE.Game;
        }

        public async Task<List<Comment>> GetAllCommentByIDandProductIDAsync(string userID, string productID, bool isSortByDate = true)
        {
           
            var filterUserID = Builders<Comment>.Filter.Eq(c => c.User.ID, userID);
            var filterProductID = Builders<Comment>.Filter.Eq(c => c.ProductID, productID);
            var combinedFilter = Builders<Comment>.Filter.And(filterUserID, filterProductID);
            List<Comment> listComment = collection.Find(combinedFilter).ToList();

            if (isSortByDate)
            {
                return listComment.OrderByDescending(c => c.CreatedAt).ToList();
            }

            return listComment;

        }


        public async Task<List<Comment>> GetCommentsByPageAsync(int page, string productID, string notUserID, bool isSortByDate = true)
        {
            int startIndex = (page - 1) * itemsPerPage;
            var filter = Builders<Comment>.Filter;
            var filterProductID = Builders<Comment>.Filter.Eq(c => c.ProductID, productID);
            List<Comment> comments;
            if (notUserID != null || notUserID != "")
            {
                var filterNotUserID = filter.Not(Builders<Comment>.Filter.Eq(c => c.User.ID, notUserID));
                var combinedFilter = Builders<Comment>.Filter.And(filterNotUserID, filterProductID);
                comments = collection.Find(combinedFilter).Skip(startIndex).Limit(itemsPerPage).ToList();
            }
            else
            {
                comments =  collection.Find(filterProductID).Skip(startIndex).Limit(itemsPerPage).ToList();
            }

            if (isSortByDate)
            {
                return comments.OrderByDescending(c => c.CreatedAt).ToList();
            }

            return comments;

        }

        public async Task<bool> InsertOneCommentsByTypeAsync(Comment comment)
        {
            try
            {
                collection.InsertOne(comment);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<DeleteResult> DeleteOneCommentsByTypeAsync(ObjectId commentID)
        {
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq("_id", commentID);
            DeleteResult result = collection.DeleteOne(filter);
            return result;
        }

        public async Task<UpdateResult> UpdateOneCommentsByTypeAsync(ObjectId commentID, string newTextContent)
        {
            FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq("_id", commentID);
            UpdateDefinition<Comment> updateDefinition = Builders<Comment>.Update.Set(c => c.Content.Text, newTextContent);

            UpdateResult result = collection.UpdateOne(filter, updateDefinition);
            return result;
        }

        public async Task<List<BsonDocument>> GetNumberOfCommentByMonthAsync(string id)
        {

            var matchStage = new BsonDocument("$match", new BsonDocument("productID", id));
            var groupStage = new BsonDocument("$group", new BsonDocument
            {
                { "_id", new BsonDocument("$month", "$createdAt") },
                { "tong", new BsonDocument("$sum", 1) }
            });

            var pipeline = new BsonDocument[] { matchStage, groupStage };

            var result = collection.Aggregate<BsonDocument>(pipeline).ToList();

            return result;

        }


    }
}
