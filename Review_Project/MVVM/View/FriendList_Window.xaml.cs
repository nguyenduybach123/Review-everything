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
using System.Windows.Shapes;

namespace Review_Project.MVVM.View
{
    /// <summary>
    /// Interaction logic for FriendList_Window.xaml
    /// </summary>
    public partial class FriendList_Window : Window
    {
        public FriendList_Window()
        {
            InitializeComponent();
        }

        public List<Follower> Followers
        {
            get { return (List<Follower>)GetValue(FollowersProperty); }
            set { SetValue(FollowersProperty, value); }
        }

        public static readonly DependencyProperty FollowersProperty = DependencyProperty.Register("Followers", typeof(List<Follower>), typeof(FriendList_Window));
    }
}
