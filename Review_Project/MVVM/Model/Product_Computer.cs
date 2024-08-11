using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Review_Project.MVVM.Model
{
    public class Product_Computer : Product
    {
        [BsonElement("computerType")]
        public string ComputerType { get; set; }

        [BsonElement("computerSmoothRating")]
        public int SmoothRating { get; set; }

        [BsonElement("computerMaterialRating")]
        public int MaterialRating { get; set; }

        [BsonElement("computerSameAsDescriptionRating")]
        public int SameAsDescriptionRating { get; set; }

        [BsonElement("computerTakeCareRating")]
        public int TakeCareRating { get; set; }
    }
}
