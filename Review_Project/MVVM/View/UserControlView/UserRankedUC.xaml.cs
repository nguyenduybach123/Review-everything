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
using Review_Project.MVVM.Model;

namespace Review_Project.MVVM.View.UserControlView
{
    /// <summary>
    /// Interaction logic for UserRankedUC.xaml
    /// </summary>
    public partial class UserRankedUC : UserControl
    {
        public UserRankedUC()
        {
            InitializeComponent();
        }

        public UserRanked UserRanked
        {
            get { return (UserRanked)GetValue(UserRankedProperty); }
            set { SetValue(UserRankedProperty, value); }
        }

        public static readonly DependencyProperty UserRankedProperty = DependencyProperty.Register("UserRanked", typeof(UserRanked), typeof(UserRankedUC));


    }
}
