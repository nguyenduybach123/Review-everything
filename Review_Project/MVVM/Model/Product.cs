using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public abstract class Product
    {
        public ObjectId Id { get; set; }

        [BsonElement("productState")]
        public int State { get; set; }

        [BsonElement("productType")]
        public string Type { get; set; } = "";

        [BsonElement("productName")]
        public string Name { get; set; } = "";

        [BsonElement("productImageList")]
        public List<string> ImageList { get; set; } = new List<string>();

        [BsonElement("productVideoList")]
        public List<string> VideoList { get; set; } = new List<string>();

        [BsonElement("productPrice")]
        public int Price { get; set; }

        [BsonElement("productDetail")]
        public string Detail { get; set; } = "";

        [BsonElement("productDecription")]
        public string Decriptions { get; set; } = "";

        [BsonElement("productCertificate")]
        public List<ProductCertificate> Certificates { get; set; } = new List<ProductCertificate>();

        [BsonElement("productRank")]
        public int Rank { get; set; }

        [BsonElement("productView")]
        public int View { get; set; }

        [BsonElement("productLike")]
        public int Like { get; set; }

        [BsonElement("productDislike")]
        public int Dislike { get; set; }

        [BsonElement("productFeedback")]
        public int NumberReview { get; set; }

        [BsonElement("productSold")]
        public int NumberSold { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public class ProductCertificate
        {
            [BsonElement("name")]
            public string Name { get; set; }

            [BsonElement("image")]
            public string Image { get; set; }
        }


    }
}
