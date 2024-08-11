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
using MaterialDesignThemes.Wpf;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for CardInfoUC.xaml
    /// </summary>
    public partial class CardInfoUC : UserControl
    {
        public CardInfoUC()
        {
            InitializeComponent();
        }


        public string Title 
        { 
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(CardInfoUC));

        public string FontSizeTitle
        {
            get { return (string)GetValue(FontSizeTitleProperty); }
            set { SetValue(FontSizeTitleProperty, value); }
        }

        public static readonly DependencyProperty FontSizeTitleProperty = DependencyProperty.Register("FontSizeTitle", typeof(string), typeof(CardInfoUC));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(CardInfoUC));

        public string FontSizeValue
        {
            get { return (string)GetValue(FontSizeValueProperty); }
            set { SetValue(FontSizeValueProperty, value); }
        }

        public static readonly DependencyProperty FontSizeValueProperty = DependencyProperty.Register("FontSizeValue", typeof(string), typeof(CardInfoUC));

        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(CardInfoUC));

        public string WidthIcon
        {
            get { return (string)GetValue(WidthIconProperty); }
            set { SetValue(WidthIconProperty, value); }
        }

        public static readonly DependencyProperty WidthIconProperty = DependencyProperty.Register("WidthIcon", typeof(string), typeof(CardInfoUC));

        public string HeightIcon
        {
            get { return (string)GetValue(HeightIconProperty); }
            set { SetValue(HeightIconProperty, value); }
        }

        public static readonly DependencyProperty HeightIconProperty = DependencyProperty.Register("HeightIcon", typeof(string), typeof(CardInfoUC));


        public Color Background1
        {
            get { return (Color)GetValue(Background1Property); }
            set { SetValue(Background1Property, value); }
        }


        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(CardInfoUC));

        public Color Background2
        {
            get { return (Color)GetValue(Background2Property); }
            set { SetValue(Background2Property, value); }
        }

        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(CardInfoUC));


        public Color BackgroundEllipse1
        {
            get { return (Color)GetValue(BackgroundEllipse1Property); }
            set { SetValue(BackgroundEllipse1Property, value); }
        }

        public static readonly DependencyProperty BackgroundEllipse1Property = DependencyProperty.Register("BackgroundEllipse1", typeof(Color), typeof(CardInfoUC));


        public Color BackgroundEllipse2
        {
            get { return (Color)GetValue(BackgroundEllipse2Property); }
            set { SetValue(BackgroundEllipse2Property, value); }
        }

        public static readonly DependencyProperty BackgroundEllipse2Property = DependencyProperty.Register("BackgroundEllipse2", typeof(Color), typeof(CardInfoUC));

        public Color IconForeground
        {
            get { return (Color)GetValue(IconForegroundProperty); }
            set { SetValue(IconForegroundProperty, value); }
        }

        public static readonly DependencyProperty IconForegroundProperty = DependencyProperty.Register("IconForeground", typeof(Color), typeof(CardInfoUC));

    }
}
