using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review_Project.MVVM.Model
{
    public class ProductCategory
    {
        [BsonElement("typeID")]
        public string typeId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

    }
}
