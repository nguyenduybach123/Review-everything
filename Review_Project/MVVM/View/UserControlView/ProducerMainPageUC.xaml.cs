using Review_Project.MVVM.Model;
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
    /// Interaction logic for ProducerMainPageUC.xaml
    /// </summary>
    public partial class ProducerMainPageUC : UserControl
    {
        public ProducerMainPageUC()
        {
            InitializeComponent();
        }

        public Producer User
        {
            get { return (Producer)GetValue(UserProperty); }
            set { SetValue(UserProperty, value); }
        }

        public static readonly DependencyProperty UserProperty = DependencyProperty.Register("User", typeof(Producer), typeof(ProducerMainPageUC));

    }
}
