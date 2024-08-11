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
using System.Windows.Media.Animation;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for CarouselUC.xaml
    /// </summary>
    public partial class CarouselUC : UserControl
    {
        public CarouselUC()
        {
            InitializeComponent();
        }

        //private void InitializeCarousel()
        //{
        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.From = 0;
        //    animation.To = -300; // Di chuyển theo trục X

        //    animation.Duration = new Duration(TimeSpan.FromSeconds(5));
        //    animation.RepeatBehavior = RepeatBehavior.Forever;

        //    TranslateTransform translateTransform = new TranslateTransform();
        //    button1.RenderTransform = translateTransform;
        //    button1.RenderTransformOrigin = new Point(0.5, 0.5);
        //    button1.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);

        //    animation = animation.Clone();
        //    animation.BeginTime = TimeSpan.FromSeconds(2); // Delay 2 giây trước khi bắt đầu di chuyển Button 2
        //    button2.RenderTransform = translateTransform;
        //    button2.RenderTransformOrigin = new Point(0.5, 0.5);
        //    button2.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        //}

        public int SlideNumber
        {
            get { return (int)GetValue(SlideNumberProperty); }
            set { SetValue(SlideNumberProperty, value); }
        }

        public static readonly DependencyProperty SlideNumberProperty = DependencyProperty.Register("SlideNumber", typeof(int), typeof(CarouselUC));


    }
}
