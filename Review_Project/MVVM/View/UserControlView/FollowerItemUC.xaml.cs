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
    /// Interaction logic for FollowerItemUC.xaml
    /// </summary>
    public partial class FollowerItemUC : UserControl
    {
        public FollowerItemUC()
        {
            InitializeComponent();
        }

        public string FollowerName
        {
            get { return (string)GetValue(FollowerNameProperty); }
            set { SetValue(FollowerNameProperty, value); }
        }

        public static readonly DependencyProperty FollowerNameProperty = DependencyProperty.Register("FollowerName", typeof(string), typeof(FollowerItemUC));


        public string ImgURL
        {
            get { return (string)GetValue(ImgURLProperty); }
            set { SetValue(ImgURLProperty, value); }
        }

        public static readonly DependencyProperty ImgURLProperty = DependencyProperty.Register("ImgURL", typeof(string), typeof(FollowerItemUC));

        public string WidthImg
        {
            get { return (string)GetValue(WidthImgProperty); }
            set { SetValue(WidthImgProperty, value); }
        }

        public static readonly DependencyProperty WidthImgProperty = DependencyProperty.Register("WidthImg", typeof(string), typeof(FollowerItemUC));

        public string HeightImg
        {
            get { return (string)GetValue(HeightImgProperty); }
            set { SetValue(HeightImgProperty, value); }
        }

        public static readonly DependencyProperty HeightImgProperty = DependencyProperty.Register("HeightImg", typeof(string), typeof(FollowerItemUC));

    }
}
