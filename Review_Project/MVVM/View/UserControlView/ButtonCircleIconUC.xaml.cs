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
    /// Interaction logic for ButtonCircleIconUC.xaml
    /// </summary>
    public partial class ButtonCircleIconUC : UserControl
    {
        public ButtonCircleIconUC()
        {
            InitializeComponent();
        }


        public string ToolTipContent
        {
            get { return (string)GetValue(ToolTipContentProperty); }
            set { SetValue(ToolTipContentProperty, value); }
        }

        public static readonly DependencyProperty ToolTipContentProperty = DependencyProperty.Register("ToolTipContent", typeof(string), typeof(ButtonCircleIconUC));

        public string WidthIcon
        {
            get { return (string)GetValue(WidthIconProperty); }
            set { SetValue(WidthIconProperty, value); }
        }

        public static readonly DependencyProperty WidthIconProperty = DependencyProperty.Register("WidthIcon", typeof(string),typeof(ButtonCircleIconUC));

        public string HeightIcon
        {
            get { return (string)GetValue(HeightIconProperty); }
            set { SetValue(HeightIconProperty, value); }
        }

        public static readonly DependencyProperty HeightIconProperty = DependencyProperty.Register("HeightIcon", typeof(string), typeof(ButtonCircleIconUC));


        public Color Background1
        {
            get { return (Color)GetValue(Background1Property); }
            set { SetValue(Background1Property, value); }
        }

        public static readonly DependencyProperty Background1Property = DependencyProperty.Register("Background1", typeof(Color), typeof(ButtonCircleIconUC));

        public Color Background2
        {
            get { return (Color)GetValue(Background2Property); }
            set { SetValue(Background2Property, value); }
        }

        public static readonly DependencyProperty Background2Property = DependencyProperty.Register("Background2", typeof(Color), typeof(ButtonCircleIconUC));


        public Color Background3
        {
            get { return (Color)GetValue(Background3Property); }
            set { SetValue(Background3Property, value); }
        }

        public static readonly DependencyProperty Background3Property = DependencyProperty.Register("Background3", typeof(Color), typeof(ButtonCircleIconUC));

        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(ButtonCircleIconUC));


        public ICommand SubmitButton
        {
            get { return (ICommand)GetValue(SubmitButtonProperty); }
            set { SetValue(SubmitButtonProperty, value); }
        }

        public static readonly DependencyProperty SubmitButtonProperty = DependencyProperty.Register("SubmitButton", typeof(ICommand), typeof(ButtonCircleIconUC));


        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(ButtonCircleIconUC));


    }
}
