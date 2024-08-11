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
    /// Interaction logic for PostContentEditorUC.xaml
    /// </summary>
    public partial class PostContentEditorUC : UserControl
    {
        public PostContentEditorUC()
        {
            InitializeComponent();
        }

        public Panel Container
        {
            get { return (Panel)GetValue(ContainerProperty); }
            set { SetValue(ContainerProperty, value); }
        }

        public static readonly DependencyProperty ContainerProperty = DependencyProperty.Register("Container", typeof(Panel), typeof(PostContentEditorUC));

    }
}
