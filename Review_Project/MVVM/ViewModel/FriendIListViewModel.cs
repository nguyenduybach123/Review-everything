using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View;
using Review_Project.MVVM.Model;
using System.IO;

namespace Review_Project.MVVM.ViewModel
{
    public class FriendIListViewModel : ObservableObject
    {
        public ICommand LoadFriendListCommand { get; set; }
        public FriendIListViewModel()
        {
            LoadFriendListCommand = new RelayCommand<FriendList_Window>((friendListWindow) => { return true; }, (friendListWindow) => {

                foreach (Follower follower in friendListWindow.Followers)
                {
                    string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                    string strImg = fullDirectory + follower.Name + "\\Avatar\\" + follower.Avatar;
                    follower.Avatar = strImg;
                }

                friendListWindow.FriendItemList.ItemsSource = friendListWindow.Followers;
            });
        }
    }
}
