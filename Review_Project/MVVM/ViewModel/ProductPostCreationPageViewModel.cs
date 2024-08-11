using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.Model.MongoDB_Connect;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductPostCreationPageViewModel : BaseViewModel
    {
        public Reviewer User { get; set; }
        public ICommand LoadedProductPostCreationPageCommand { get; set; }
        public ICommand SubmitButtonAddEditorCommand { get; set; }
        public ICommand LoadCbxPostTypeCommand { get; set; }
        public ICommand SubmitButtonCreatePostCommand { get; set; }

        public ProductPostCreationPageViewModel()
        {
            LoadedProductPostCreationPageCommand = new RelayCommand<ProductPostCreationPageUC>((postCreationUC) => { return true; }, (postCreationUC) => {

                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                User = mainWindowVM.ReviewerUser;

                PostContentEditorUC postEditor = new PostContentEditorUC();
                postEditor.Width = 800;
                postEditor.Height = 400;
                postEditor.Margin = new Thickness(0, 10, 0, 10);
                postEditor.Container = postCreationUC.EditorContainer;
                postCreationUC.EditorContainer.Children.Add(postEditor);
            });

            SubmitButtonAddEditorCommand = new RelayCommand<ProductPostCreationPageUC>((postCreationUC) => { return true; }, (postCreationUC) => {
                PostContentEditorUC postEditor = new PostContentEditorUC();
                postEditor.Width = 800;
                postEditor.Height = 400;
                postEditor.Margin = new Thickness(0, 10, 0, 10);
                postEditor.Container = postCreationUC.EditorContainer;
                postCreationUC.EditorContainer.Children.Add(postEditor);
            });


            LoadCbxPostTypeCommand = new RelayCommand<ProductPostCreationPageUC>((postCreationUC) => { return true; }, (postCreationUC) => {
                using (DB_SocialReviewDataContext db = new DB_SocialReviewDataContext())
                {
                    List<PRODUCT_CATEGORY> categoryList = db.PRODUCT_CATEGORies.ToList();
                    postCreationUC.cbxPostType.ItemsSource = categoryList;
                    postCreationUC.cbxPostType.DisplayMemberPath = "CATEGORY_NAME";
                    postCreationUC.cbxPostType.SelectedValuePath = "CATEGORY_CODE";

                    postCreationUC.cbxPostType.SelectedIndex = 0;

                }
            });


            SubmitButtonCreatePostCommand = new RelayCommand<ProductPostCreationPageUC>((postCreationUC) => { return true; }, async (postCreationUC) => {
                try
                {

                    PRODUCT_CATEGORY category = postCreationUC.cbxPostType.SelectedItem as PRODUCT_CATEGORY;
                    string hashFileName = DataEncryptor.CalculateStringHash(postCreationUC.txtPostTitle.Text);

                    Post post = null;
                    if (category.CATEGORY_CODE == "game")
                    {
                        post = new Post_Game();
                        post.Type = "game";
                        post.Title = postCreationUC.txtPostTitle.Text;
                        post.User.Name = User.Name;
                        post.User.Avatar = User.Avatar;
                        post.XML = hashFileName;
                        post.CreatedAt = DateTime.Now;
                    }
                    else if (category.CATEGORY_CODE == "computer")
                    {
                        post = new Post_Computer();
                        post.Type = "computer";
                        post.Title = postCreationUC.txtPostTitle.Text;
                        post.User.Name = User.Name;
                        post.User.Avatar = User.Avatar;
                        post.XML = hashFileName;
                        post.CreatedAt = DateTime.Now;
                    }
                    else if (category.CATEGORY_CODE == "movie")
                    {
                        post = new Post_Movie();
                        post.Type = "movie";
                        post.Title = postCreationUC.txtPostTitle.Text;
                        post.User.Name = User.Name;
                        post.User.Avatar = User.Avatar;
                        post.XML = hashFileName;
                        post.CreatedAt = DateTime.Now;
                    }

                    post.ProductID = postCreationUC.txtProductID.Text;

                    bool isPostValid = await ValidationPostHandling.PostValidation(post);

                    if (!isPostValid)
                    {
                        post = null;
                        return;
                    }

                    string fullPathDirectory = Path.GetFullPath("..//..//Posts//Reviewer//");
                    string postFileXMLPath = fullPathDirectory + User.Name + "\\" + hashFileName + ".xml";

                    XmlPostGenerator postFileXML = new XmlPostGenerator(postFileXMLPath);

                    bool isSucess = false;
                    foreach (PostContentEditorUC postEditor in postCreationUC.EditorContainer.Children)
                    {
                        PostContent postContent = new PostContent(postEditor.txtTitle.Text, postEditor.postContent.Document);
                        isSucess = postFileXML.WritePostFileXML(postContent);
                    }

                    if (isSucess)
                    {
                        bool isInsertSucess = false;
                        if(post.Type == "game")
                        {
                            Post_GameDBHandler dbPostGame = new Post_GameDBHandler();
                            isInsertSucess = await dbPostGame.InsertOnePostAsync(post as Post_Game);
                        }
                        else if(post.Type == "computer")
                        {
                            Post_ComputerDBHandler dbPostComputer = new Post_ComputerDBHandler();
                            isInsertSucess = await dbPostComputer.InsertOnePostAsync(post as Post_Computer);
                        }
                        else if(post.Type == "movie")
                        {
                            Post_MovieDBHandler dbPostMovie = new Post_MovieDBHandler();
                            isInsertSucess = await dbPostMovie.InsertOnePostAsync(post as Post_Movie);
                        }

                        if (!isInsertSucess)
                        {
                            MessageBox.Show("Tạo bài viết thất bại !!", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tạo bài viết thất bại !!!", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    MessageBox.Show("Tạo bài viết Thành công", "Thành Công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo bài viết thất bại !!!", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

            });

        }

    }
}
