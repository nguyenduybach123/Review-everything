using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;
using System.Windows;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductPostListViewModel : BaseViewModel
    {
        public string ProductID { get; set; }
        public string ProductType { get; set; }



        public ICommand LoadProductPostListCommand { get; set; }
        public ProductPostListViewModel()
        {
            LoadProductPostListCommand = new RelayCommand<ProductPostListUC>((productListUC) => { return true; }, async (productListUC) => {
                try
                {
                    if(ProductType == "Game")
                    {
                        Post_GameDBHandler db = new Post_GameDBHandler();
                        List<Post_Game> postlist = await db.GetPostByProductIDAsync(ProductID);

                        if(postlist.Count() == 0)
                        {
                            productListUC.emptyBox.Visibility = Visibility.Visible;
                            return;
                        }

                        productListUC.emptyBox.Visibility = Visibility.Collapsed;

                        foreach (Post_Game post in postlist)
                        {
                            string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                            string resourceImg = fullDirectory + post.User.Name +  "\\Avatar\\" + post.User.Avatar;
                            post.User.Avatar = resourceImg;
                        }

                        productListUC.postContainer.ItemsSource = postlist;
                    }
                    else if(ProductType == "Computer")
                    {
                        Post_ComputerDBHandler db = new Post_ComputerDBHandler();
                        List<Post_Computer> postlist = await db.GetPostByProductIDAsync(ProductID);

                        if (postlist.Count() == 0)
                        {
                            productListUC.emptyBox.Visibility = Visibility.Visible;
                            return;
                        }

                        productListUC.emptyBox.Visibility = Visibility.Collapsed;

                        foreach (Post_Computer post in postlist)
                        {
                            string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                            string resourceImg = fullDirectory + post.User.Name + "\\Avatar\\" + post.User.Avatar;
                            post.User.Avatar = resourceImg;
                        }
                        productListUC.postContainer.ItemsSource = postlist;
                    }
                    else if( ProductType == "Movie")
                    {
                        Post_MovieDBHandler db = new Post_MovieDBHandler();
                        List<Post_Movie> postlist = await db.GetPostByProductIDAsync(ProductID);

                        if (postlist.Count() == 0)
                        {
                            productListUC.emptyBox.Visibility = Visibility.Visible;
                            return;
                        }

                        productListUC.emptyBox.Visibility = Visibility.Collapsed;

                        foreach (Post_Movie post in postlist)
                        {
                            string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                            string resourceImg = fullDirectory + post.User.Name + "\\Avatar\\" + post.User.Avatar;
                            post.User.Avatar = resourceImg;
                        }
                        productListUC.postContainer.ItemsSource = postlist;
                    }
                }
                catch (Exception ex)
                {

                }
            });
        }

        public void PostItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Border itemContainer = sender as Border;
            Post post = itemContainer.DataContext as Post;

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

            if (mainWindowVM.CurrentView is ReviewerMainPageViewModel reviewerMainUC)
            {
                ProductPostViewPageViewModel postViewPageVM = new ProductPostViewPageViewModel();
                postViewPageVM.Post = post;
                reviewerMainUC.controlViewPage_ProductPage.Push<ProductPostViewPageViewModel>(postViewPageVM);

                object lastViewPage = null;
                reviewerMainUC.controlViewPage_ProductPage.getLastViewPage(ref lastViewPage);
                reviewerMainUC.CurrentView = lastViewPage;
            }

        }

    }
}
