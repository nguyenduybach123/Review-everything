using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class PostTypeCare
    {
        [BsonElement("typeName")]
        public string Title { get; set; }

        [BsonElement("amount")]
        public int Amount { get; set; }

    }
}
