using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Reviewer
    {
        public ObjectId Id { get; set; }

        [BsonElement("userState")]
        public int State { get; set; }

        [BsonElement("userName")]
        public string Name { get; set; } = "";

        [BsonElement("userAvatar")]
        public string Avatar { get; set; } = "";

        [BsonElement("userDate")]
        public string CreateDate { get; set; } = "";

        [BsonElement("userGmail")]
        public string Gmail { get; set; } = "";

        [BsonElement("userDecription")]
        public string Decription { get; set; } = "";

        [BsonElement("userRating")]
        public int Rating { get; set; }

        [BsonElement("userPrestige")]
        public int Prestige { get; set; }

        [BsonElement("userTotalLike")]
        public int Like { get; set; }

        [BsonElement("userTotalDislike")]
        public int Dislike { get; set; }

        [BsonElement("userRank")]
        public int Rank { get; set; }

        [BsonElement("userFollowers")]
        public List<Follower> FollowerList { get; set; } = new List<Follower>();

        [BsonElement("userPosts")]
        public int NumberPost { get; set; }

        [BsonElement("userPostType")]
        public List<PostTypeCare> PostTypeList { get; set; } = new List<PostTypeCare>();
        [BsonElement("userAchievement")]
        public List<Achievement> AchievementList { get; set; } = new List<Achievement>();

        [BsonElement("userSold")]
        public List<string> ProductSold { get; set; } = new List<string>();


    }
}
