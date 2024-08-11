using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Producer
    {
        public ObjectId Id { get; set; }

        [BsonElement("userState")]
        public int State { get; set; }

        [BsonElement("userName")]
        public string Name { get; set; } = "";

        [BsonElement("userAvatar")]
        public string Avatar { get; set; } = "";

        [BsonElement("userDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [BsonElement("userGmail")]
        public string Gmail { get; set; } = "";

        [BsonElement("userDecription")]
        public string Decription { get; set; } = "";

        [BsonElement("userPrestige")]
        public int Prestige { get; set; }

        [BsonElement("userTotalLike")]
        public int Like { get; set; }

        [BsonElement("userTotalDislike")]
        public int Dislike { get; set; }

        [BsonElement("userTotalFollower")]
        public int NumberFollower { get; set; }

        [BsonElement("userRank")]
        public int Rank { get; set; }

        [BsonElement("userFollowers")]
        public List<Follower> FollowerList { get; set; } = new List<Follower>();

        [BsonElement("userPosts")]
        public List<PostVM> PostList { get; set; } = new List<PostVM>();

        [BsonElement("userAchievement")]
        public List<Achievement> AchievementList { get; set; } = new List<Achievement>();

        [BsonElement("userProducts")]
        public List<string> Products { get; set; } = new List<string>();

        [BsonElement("userProductHots")]
        public List<string> ProductHots { get; set; } = new List<string>();

        [BsonElement("userResponseRate")]
        public int ResponseRate { get; set; } = 0;
    }
}
