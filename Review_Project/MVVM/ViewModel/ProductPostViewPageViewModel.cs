using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductPostViewPageViewModel
    {
        public Post Post { get; set; }
        public ICommand LoadProductPostViewCommand { get; set; }
        public ICommand SubmitBackPreviousViewPageCommand { get; set; }
        public ProductPostViewPageViewModel()
        {
            LoadProductPostViewCommand = new RelayCommand<ProductPostViewPageUC>((PostContentItemUC) => { return true; }, async (PostContentItemUC) => {
                try
                {
                    PostContentItemUC.userImg.ImageSource = new BitmapImage(new Uri(Post.User.Avatar));
                    PostContentItemUC.userName.Text = Post.User.Name;
                    PostContentItemUC.postCreatedAt.Text = Post.CreatedAt.ToString();
                    PostContentItemUC.postView.Text = Post.View.ToString();
                    PostContentItemUC.postComment.Text = Post.Comment.ToString();

                    XmlDocument xmlDoc = new XmlDocument();

                    string fullDirectory = Path.GetFullPath("..//..//Posts//Reviewer//");
                    string resourceXML = fullDirectory + Post.User.Name + "\\" + Post.XML + ".xml";
                    xmlDoc.Load(resourceXML);

                    StackPanel panelContainer = new StackPanel();
                    XmlNode contentElement = xmlDoc.SelectSingleNode("/Contents") as XmlElement;

                    XmlPostGenerator.CreateUIFromXMLFile(contentElement, panelContainer);

                    PostContentItemUC.txbPostTitle.Text = Post.Title;
                    PostContentItemUC.contentContainer.Children.Add(panelContainer);

                }
                catch (Exception ex)
                {

                }
            });


            SubmitBackPreviousViewPageCommand = new RelayCommand<ProductPostViewPageUC>((PostContentItemUC) => { return true; }, async (PostContentItemUC) => {
                Window mainWindow = Window.GetWindow(PostContentItemUC);
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                if (mainWindowVM.CurrentView is ReviewerMainPageViewModel reviewerMainUC)
                {
                    object previousViewPage = null;
                    reviewerMainUC.controlViewPage_ProductPage.getPreviousViewPage(ref previousViewPage);
                    reviewerMainUC.CurrentView = previousViewPage;
                }
            });

        }
    }
}
