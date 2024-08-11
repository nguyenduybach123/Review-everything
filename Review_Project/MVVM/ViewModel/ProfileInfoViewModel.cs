using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.View;
using Review_Project.MVVM.Model;
using System.Windows.Input;
using Review_Project.Core;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using System.IO;

namespace Review_Project.MVVM.ViewModel
{
    public class ProfileInfoViewModel : BaseViewModel
    {

        public ICommand LoadProfileCommand { get; set; }
        public ICommand OpenFriendListWindowCommand { get; set; }
        public ProfileInfoViewModel()
        {
            LoadProfileCommand = new RelayCommand<ProfileInfoUC>((profileUC) => { return true; }, async (profileUC) =>
            {
                try
                {
                    Window mainWindow = Window.GetWindow(profileUC);
                    MainWindowViewModel mainWindowDataContext = mainWindow.DataContext as MainWindowViewModel;
                    Reviewer reviewer = mainWindowDataContext.ReviewerUser;

                    string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                    string strImg = fullDirectory + reviewer.Name + "\\Avatar\\" + reviewer.Avatar;
                    profileUC.userImg.ImageSource = new BitmapImage(new Uri(strImg));
                    profileUC.userName.Text = reviewer.Name;
                    profileUC.userStarRating.Value = reviewer.Rating;
                    profileUC.userPointRating.Text = reviewer.Rating.ToString();
                    profileUC.txbLike.Text = "Like : " + reviewer.Like;
                    profileUC.txbDisLike.Text = "Dislike : " + reviewer.Dislike;

                    if (reviewer.PostTypeList.Count() == 0)
                    {
                        profileUC.emptyBox.Visibility = Visibility.Visible;
                    }
                    else
                    {

                        profileUC.emptyBox.Visibility = Visibility.Collapsed;

                        int summaryPostTypeList = reviewer.PostTypeList.Sum(pt => pt.Amount);

                        foreach (PostTypeCare postType in reviewer.PostTypeList)
                        {
                            ActivityMeterUC amUC = new ActivityMeterUC();
                            amUC.Title = postType.Title;
                            amUC.Value = postType.Amount;
                            amUC.Summary = summaryPostTypeList;
                            if (postType.Title == "Game")
                            {
                                amUC.Icon = PackIconKind.ControllerClassic;
                            }
                            else if (postType.Title == "Movie")
                            {
                                amUC.Icon = PackIconKind.MovieRoll;
                            }
                            else if (postType.Title == "Computer")
                            {
                                amUC.Icon = PackIconKind.Laptop;
                            }
                            SettingStylePostTypeCare(amUC);

                            profileUC.userPostTypeCare.Children.Add(amUC);
                        }
                    }
                    
                    if(reviewer.FollowerList.Count() == 0)
                    {
                        profileUC.emptyFriend.Visibility = Visibility.Visible;
                        profileUC.btnFriendSeeMore.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        profileUC.emptyFriend.Visibility = Visibility.Collapsed;
                        profileUC.btnFriendSeeMore.Visibility = Visibility.Visible;
                        foreach (Follower follower in reviewer.FollowerList)
                        {
                            FollowerItemUC followerUC = new FollowerItemUC();
                            string followerImg = fullDirectory + follower.Name + "\\Avatar\\" + follower.Avatar;
                            followerUC.followerImg.ImageSource = new BitmapImage(new Uri(followerImg));
                            followerUC.WidthImg = "50";
                            followerUC.HeightImg = "50";
                            followerUC.followerName.Text = follower.Name;
                            profileUC.userFollowerList.Children.Add(followerUC);
                        }
                    }

                    profileUC.userNumberPost.Value = reviewer.NumberPost.ToString();
                    profileUC.userNumber.Value = reviewer.Prestige.ToString();
                    profileUC.userNumberFollower.Value = reviewer.FollowerList.Count().ToString();

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR ERROR ERROR !!!!! : /n" + ex);
                }

                //profileUC.userName.Text = userReviewer.Name;

                //string startupPath = System.IO.Directory.GetCurrentDirectory();
                //string strImg = startupPath + "\\Images\\Avatar\\" + userReviewer.Avatar + ".jpg";
                //profileUC.userImg.ImageSource = new BitmapImage(new Uri(strImg));

                //profileUC.userPesitage.Text = userReviewer.Prestige.ToString();
                //profileUC.userRating.Value = userReviewer.Rating;
                //profileUC.userLike.Text = userReviewer.Like.ToString();
                //profileUC.userDislike.Text = userReviewer.Dislike.ToString();

            });

            OpenFriendListWindowCommand = new RelayCommand<ProfileInfoUC>((profileUC) => { return true; }, async (profileUC) => {

                Window mainWindow = Window.GetWindow(profileUC);
                MainWindowViewModel mainWindowDataContext = mainWindow.DataContext as MainWindowViewModel;
                Reviewer reviewer = mainWindowDataContext.ReviewerUser;

                FriendList_Window friendWindow = new FriendList_Window();
                friendWindow.Followers = reviewer.FollowerList;
                friendWindow.ShowDialog();
            });
        }

        private void SettingStylePostTypeCare(ActivityMeterUC amUC)
        {
            amUC.Background1 = Color.FromRgb(255, 153, 51);
            amUC.Background2 = Color.FromRgb(255, 153, 102);
            amUC.FontSizeTitle = "16";
            amUC.FontSizeValue = "18";
            amUC.WidthIcon = "30";
            amUC.HeightIcon = "30";
            amUC.WidthProgress = 300;
        }
    }
}
