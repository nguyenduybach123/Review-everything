using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for CardAnalysisProduct.xaml
    /// </summary>
    public partial class CardAnalysisProduct : UserControl
    {
        public CardAnalysisProduct()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(CardAnalysisProduct));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(CardAnalysisProduct));

        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(CardAnalysisProduct));

        public string WidthIcon
        {
            get { return (string)GetValue(WidthIconProperty); }
            set { SetValue(WidthIconProperty, value); }
        }

        public static readonly DependencyProperty WidthIconProperty = DependencyProperty.Register("WidthIcon", typeof(string), typeof(CardAnalysisProduct));

        public string HeightIcon
        {
            get { return (string)GetValue(HeightIconProperty); }
            set { SetValue(HeightIconProperty, value); }
        }

        public static readonly DependencyProperty HeightIconProperty = DependencyProperty.Register("HeightIcon", typeof(string), typeof(CardAnalysisProduct));


        public Color BackgroundIcon1
        {
            get { return (Color)GetValue(BackgroundIcon1Property); }
            set { SetValue(BackgroundIcon1Property, value); }
        }


        public static readonly DependencyProperty BackgroundIcon1Property = DependencyProperty.Register("BackgroundIcon1", typeof(Color), typeof(CardAnalysisProduct));


        public Color BackgroundIcon2
        {
            get { return (Color)GetValue(BackgroundIcon2Property); }
            set { SetValue(BackgroundIcon2Property, value); }
        }


        public static readonly DependencyProperty BackgroundIcon2Property = DependencyProperty.Register("BackgroundIcon2", typeof(Color), typeof(CardAnalysisProduct));


        public Color Background1
        {
            get { return (Color)GetValue(Background1Property); }
            set { SetValue(Background1Property, value); }
        }


        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(CardAnalysisProduct));

        public Color Background2
        {
            get { return (Color)GetValue(Background2Property); }
            set { SetValue(Background2Property, value); }
        }

        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(CardAnalysisProduct));


    }
}
