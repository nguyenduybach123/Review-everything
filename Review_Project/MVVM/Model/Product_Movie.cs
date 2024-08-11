using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Product_Movie : Product
    {
        [BsonElement("movieType")]
        public string MovieType { get; set; }

        [BsonElement("movieGraphicRating")]
        public int GraphicRating { get; set; }

        [BsonElement("movieStoryRating")]
        public int StoryRating { get; set; }

        [BsonElement("movieSoundRating")]
        public int SoundRating { get; set; }

        [BsonElement("movieSameAsDescriptionRating")]
        public int SameAsDescriptionRating { get; set; }
    }
}
