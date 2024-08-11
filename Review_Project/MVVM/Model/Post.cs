using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public abstract class Post
    {
        public Post()
        {
            Type = "Game";
            Title = "";
            XML = "";
            User = new UserPost();
            View = 0;
            Comment = 0;
            Like = 0;
        }

        public ObjectId Id { get; set; }

        [BsonElement("postType")]
        public string Type { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }

        [BsonElement("postTitle")]
        public string Title { get; set; }

        [BsonElement("postXML")]
        public string XML { get; set; }

        [BsonElement("postUser")]
        public UserPost User { get; set; }

        [BsonElement("postView")]
        public int View { get; set; }

        [BsonElement("postComment")]
        public int Comment { get; set; }

        [BsonElement("postLike")]
        public int Like { get; set; }

        [BsonElement("postTags")]
        public List<string> Tags { get; set; } = new List<string>();

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        public class UserPost
        {
            [BsonElement("name")]
            public string Name { get; set; }

            [BsonElement("avatar")]
            public string Avatar { get; set; }

            [BsonElement("detail")]
            public string Detail { get; set; }
        }
    }
}
