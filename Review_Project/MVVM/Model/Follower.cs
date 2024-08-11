using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Follower
    {
        [BsonElement("followerID")]
        public string ID { get; set; }

        [BsonElement("followerName")]
        public string Name { get; set; }

        [BsonElement("followerAvatar")]
        public string Avatar { get; set; }
    }
}
