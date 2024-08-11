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
    /// Interaction logic for CircularProgressBarUC.xaml
    /// </summary>
    public partial class CircularProgressBarUC : UserControl
    {
        public CircularProgressBarUC()
        {
            InitializeComponent();
        }

        //public int Radius
        //{
        //    get { return (int)GetValue(RadiusProperty); }
        //    set { SetValue(RadiusProperty, value); }
        //}

        //public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(int), typeof(CircularProgressBarUC), new PropertyMetadata(25, new PropertyChangedCallback(OnPropertyChanged()));

        //public Brush SegmentColor
        //{
        //    get { return (Brush)GetValue(SegmentColorProperty); }
        //    private set { SetValue(SegmentColorProperty, value); }
        //}

        //public static readonly DependencyProperty SegmentColorProperty = DependencyProperty.Register("SegmentColor", typeof(Brush), typeof(CircularProgressBarUC), new PropertyMetadata(new SolidColorBrush(Colors.Red));

        //public int StrokeThickness
        //{
        //    get { return (int)GetValue(StrokeThicknessProperty); }
        //    private set { SetValue(StrokeThicknessProperty, value); }
        //}

        //public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register("StrokeThickness", typeof(int), typeof(CircularProgressBarUC), new PropertyMetadata(25, new PropertyChangedCallback(OnPro)));

        //public double Percentage
        //{
        //    get { return (double)GetValue(PercentageProperty); }
        //    set { SetValue(PercentageProperty, value); }
        //}

        //public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("Percentage", typeof(double), typeof(CircularProgressBarUC), new PropertyMetadata(25, new PropertyChangedCallback()));

        //public double Angle
        //{
        //    get { return (double)GetValue(AngleProperty); }
        //    set { SetValue(AngleProperty, value); }
        //}

        //public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBarUC), new PropertyMetadata(25, new PropertyChangedCallback(OnPro)));
    }
}
