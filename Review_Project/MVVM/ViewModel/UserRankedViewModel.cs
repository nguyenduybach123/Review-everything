using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class UserRankedViewModel : BaseViewModel
    {
        public ICommand LoadUserRankedCommand { get; set; }
        public UserRankedViewModel()
        {
            LoadUserRankedCommand = new RelayCommand<UserRankedUC>((userRankUC) => { return true; }, async (userRankUC) => {

                UserRanked user = userRankUC.UserRanked;

                if (user.Rank == 1)
                {
                    userRankUC.userRank.Kind = MaterialDesignThemes.Wpf.PackIconKind.Crown;
                }
                else if (user.Rank == 2)
                {
                    userRankUC.userRank.Kind = MaterialDesignThemes.Wpf.PackIconKind.Numeric2Circle;
                }
                else
                {
                    userRankUC.userRank.Kind = MaterialDesignThemes.Wpf.PackIconKind.Numeric3Circle;
                }

                string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                string strImg = fullDirectory + user.Name + "\\Avatar\\" + user.Avatar;
                userRankUC.userImg.ImageSource = new BitmapImage(new Uri(strImg));

                userRankUC.userName.Text = user.Name;

                userRankUC.userLike.Text = user.Like.ToString();

            });
        }
    }
}
