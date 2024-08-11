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
using Review_Project.MVVM.ViewModel;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for ProductImageListUC.xaml
    /// </summary>
    public partial class ProductImageListUC : UserControl
    {
        public ProductImageListUC()
        {
            InitializeComponent();
            ImageList = new List<string>();
            VideoList = new List<string>();
        }

        public List<string> ImageList
        {
            get { return (List<string>)GetValue(ImageListProperty); }
            set { SetValue(ImageListProperty, value); }
        }

        public static readonly DependencyProperty ImageListProperty = DependencyProperty.Register("ImageList", typeof(List<string>), typeof(ProductImageListUC));

        public List<string> VideoList
        {
            get { return (List<string>)GetValue(VideoListProperty); }
            set { SetValue(VideoListProperty, value); }
        }

        public static readonly DependencyProperty VideoListProperty = DependencyProperty.Register("VideoList", typeof(List<string>), typeof(ProductImageListUC));

    }
}
