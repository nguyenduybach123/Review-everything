using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for ProductDetailReviewPageUC.xaml
    /// </summary>
    public partial class ProductDetailReviewPageUC : UserControl
    {
        public ProductDetailReviewPageUC()
        {
            InitializeComponent();
        }

        public string ProductID
        {
            get { return (string)GetValue(ProductIDProperty); }
            set { SetValue(ProductIDProperty, value); }
        }

        public static readonly DependencyProperty ProductIDProperty = DependencyProperty.Register("ProductID", typeof(string), typeof(ProductDetailReviewPageUC));

        public string ProductType
        {
            get { return (string)GetValue(ProductTypeProperty); }
            set { SetValue(ProductTypeProperty, value); }
        }

        public static readonly DependencyProperty ProductTypeProperty = DependencyProperty.Register("ProductType", typeof(string), typeof(ProductDetailReviewPageUC));

    }
}
