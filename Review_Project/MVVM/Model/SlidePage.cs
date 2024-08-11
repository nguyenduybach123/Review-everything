using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MongoDB.Bson;

namespace Review_Project.MVVM.Model
{
    public class SlidePage
    {
        private ObjectId productID;
        private string imageURL;
        private Control slideControl;

        public ObjectId ProductID { get { return productID; } set { productID = value; } }
        public string ImageURL { get { return imageURL; } set { imageURL = value; } }
        public Control SlideControl { get { return slideControl; } set { slideControl = value; } }

        public SlidePage(){

        }
    }
}
