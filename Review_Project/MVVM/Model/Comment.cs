using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Comment
    {

        public Comment()
        {
            User = new UserComment();
            Content = new CommentContent();
            Content.ImageURLList = new List<string>();
        }
        public ObjectId Id { get; set; }

        [BsonElement("userComment")]
        public UserComment User { get; set; }

        [BsonElement("productID")]
        public string ProductID { get; set; }

        [BsonElement("commentContent")]
        public CommentContent Content { get; set; }

        [BsonElement("commentRating")]
        public int Rating { get; set; }

        [BsonElement("commentLike")]
        public int Like { get; set; }

        [BsonElement("commentDislike")]
        public int Dislike { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }


        public class UserComment
        {
            [BsonElement("userID")]
            public string ID { get; set; }

            [BsonElement("userName")]
            public string Name { get; set; }

            [BsonElement("userAvatar")]
            public string Avatar { get; set; }
        }


        public class CommentContent
        {
            [BsonElement("text")]
            public string Text { get; set; }

            [BsonElement("videoURL")]
            public string VideoURL { get; set; }

            [BsonElement("imageURLs")]
            public List<string> ImageURLList { get; set; }
        }
    }
}
