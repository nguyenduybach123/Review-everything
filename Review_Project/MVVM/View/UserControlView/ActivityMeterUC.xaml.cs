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
    /// Interaction logic for ActivityMeterUC.xaml
    /// </summary>
    public partial class ActivityMeterUC : UserControl
    {
        public ActivityMeterUC()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ActivityMeterUC));

        public string FontSizeTitle
        {
            get { return (string)GetValue(FontSizeTitleProperty); }
            set { SetValue(FontSizeTitleProperty, value); }
        }

        public static readonly DependencyProperty FontSizeTitleProperty = DependencyProperty.Register("FontSizeTitle", typeof(string), typeof(ActivityMeterUC));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(int), typeof(ActivityMeterUC));

        public int Summary
        {
            get { return (int)GetValue(SummaryProperty); }
            set { SetValue(SummaryProperty, value); }
        }

        public static readonly DependencyProperty SummaryProperty = DependencyProperty.Register("Summary", typeof(int), typeof(ActivityMeterUC));

        public int WidthProgress
        {
            get { return (int)GetValue(WidthProgressProperty); }
            set { SetValue(WidthProgressProperty, value); }
        }

        public static readonly DependencyProperty WidthProgressProperty = DependencyProperty.Register("WidthProgress", typeof(int), typeof(ActivityMeterUC));

        public int HeightProgress
        {
            get { return (int)GetValue(HeightProgressProperty); }
            set { SetValue(HeightProgressProperty, value); }
        }

        public static readonly DependencyProperty HeightProgressProperty = DependencyProperty.Register("HeightProgress", typeof(int), typeof(ActivityMeterUC));

        public string FontSizeValue
        {
            get { return (string)GetValue(FontSizeValueProperty); }
            set { SetValue(FontSizeValueProperty, value); }
        }

        public static readonly DependencyProperty FontSizeValueProperty = DependencyProperty.Register("FontSizeValue", typeof(string), typeof(ActivityMeterUC));


        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(ActivityMeterUC));

        public string WidthIcon
        {
            get { return (string)GetValue(WidthIconProperty); }
            set { SetValue(WidthIconProperty, value); }
        }

        public static readonly DependencyProperty WidthIconProperty = DependencyProperty.Register("WidthIcon", typeof(string), typeof(ActivityMeterUC));

        public string HeightIcon
        {
            get { return (string)GetValue(HeightIconProperty); }
            set { SetValue(HeightIconProperty, value); }
        }

        public static readonly DependencyProperty HeightIconProperty = DependencyProperty.Register("HeightIcon", typeof(string), typeof(ActivityMeterUC));


        public Color Background1
        {
            get { return (Color)GetValue(Background1Property); }
            set { SetValue(Background1Property, value); }
        }


        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(ActivityMeterUC));

        public Color Background2
        {
            get { return (Color)GetValue(Background2Property); }
            set { SetValue(Background2Property, value); }
        }

        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(ActivityMeterUC));
    }
}
