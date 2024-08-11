using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Product_Game : Product
    {
        [BsonElement("gameType")]
        public string GameType { get; set; }

        [BsonElement("gameStoryRating")]
        public int StoryRating { get; set; }

        [BsonElement("gamePlayRating")]
        public int GamePlayRating { get; set; }

        [BsonElement("gameSoundRating")]
        public int SoundRating { get; set; }

        [BsonElement("gameGraphicRating")]
        public int GraphicRating { get; set; }
    }
}
