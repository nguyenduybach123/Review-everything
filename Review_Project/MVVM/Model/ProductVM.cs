using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class ProductVM
    {
        
        public ProductVM()
        {
            Type = new ProductCategory();
        }
        
        public ObjectId Id { get; set; }

        [BsonElement("productID")]
        public string productID { get; set; }

        [BsonElement("productType")]
        public ProductCategory Type { get; set; }

        [BsonElement("productAvatar")]
        public string Avatar { get; set; }

        [BsonElement("productName")]
        public string Name { get; set; }

        [BsonElement("productRating")]
        public int Rating { get; set; }

        [BsonElement("productRank")]
        public int Rank { get; set; }

        [BsonElement("productView")]
        public int View { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("producer")]
        public ProducerVM Producer { get; set; } = new ProducerVM();

        public class ProducerVM
        {
            [BsonElement("name")]
            public string Name { get; set; } = "";

            [BsonElement("avatar")]
            public string avatar { get; set; } = "";

            [BsonElement("producerID")]
            public string producerID { get; set; } = "";

        }

    }
}
