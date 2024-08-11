using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductCommentPageViewModel : BaseViewModel
    {

        public Reviewer Reviewer { get; set; }
        public string ProductID { get; set; }
        public string CommentType { get; set; }
        public Grid UserCommentInput { get; set; }

        private List<string> ImageUserCommentList;

        public int CurrentPage { get; set; }
        public int AmoutCommentCurrent { get; set; }

        public bool IsEmpty { get; set; }

        public ICommand LoadedProductCommentPageCommand { get; set; }
        public ICommand LoadedSubmitButtonCommand { get; set; }
        public ICommand LoadedCommentContainerCommand { get; set; }
        public ICommand SubmitCommentButtonCommand { get; set; }
        public ICommand TextChangedCommentInputCommand { get; set; }
        public ICommand SubmitMediaButtonCommand { get; set; }
        public ICommand SubmitCloseMediaButtonCommand { get; set; }
        public ICommand SubmitSeeMoreCommentCommand { get; set; }
        public ProductCommentPageViewModel()
        {
            LoadedProductCommentPageCommand = new RelayCommand<ProductDetailReviewPageUC>((commentPageUC) => { return true; }, async (commentPageUC) => {
                
                ImageUserCommentList = new List<string>();

                AmoutCommentCurrent = 0;

                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                Reviewer = mainWindowVM.ReviewerUser;

                if (Reviewer == null)
                    return;

                string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                string strImg = fullDirectory + Reviewer.Name + "\\Avatar\\" + Reviewer.Avatar;
               
                commentPageUC.userImg.ImageSource = new BitmapImage(new Uri(strImg));


                if (ProductID == null)
                    return;

                ReviewerDBHandler reviewerDB = new ReviewerDBHandler();
                bool exists = await reviewerDB.CheckReviewrProductSoldAsync(Reviewer.Id.ToString(),ProductID);

                if (!exists)
                {
                    commentPageUC.userComment.Visibility = Visibility.Collapsed;
                }

                UserCommentInput = commentPageUC.userComment;

                CurrentPage = 0;

                IsEmpty = false;
                

            });

            LoadedCommentContainerCommand = new RelayCommand<ProductDetailReviewPageUC>((commentPageUC) => { return true; }, async (commentPageUC) =>
            {
                try
                {
                    CurrentPage = 0;
                    AmoutCommentCurrent = 0;
                    CommentDBHandler commentDB = new CommentDBHandler(CommentType);
                    List<Comment> comments = await commentDB.GetAllCommentByIDandProductIDAsync(Reviewer.Id.ToString(),ProductID);
                    AmoutCommentCurrent += comments.Count();

                    if(comments.Count() == 0)
                    {
                        this.SubmitSeeMoreCommentCommand.Execute(commentPageUC);
                        return;
                    }


                    commentPageUC.emptyBox.Visibility = Visibility.Collapsed;
                    foreach (Comment comment in comments)
                    {
                        ProductCommentUC commentItem = new ProductCommentUC();
                        commentItem.Comment = comment;
                        commentItem.CommentType = CommentType;
                        commentItem.CommentContainer = commentPageUC.CommentContainer;


                        if (comment.User.ID == Reviewer.Id.ToString())
                        {
                            commentItem.IsCurrentUser = true;
                        }

                        commentPageUC.CommentContainer.Children.Add(commentItem);
                    }

                    if(AmoutCommentCurrent >= commentDB.GetCountDocumentByProductID(ProductID))
                    {
                        commentPageUC.btnSeeMore.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        commentPageUC.btnSeeMore.Visibility = Visibility.Visible;
                    }

                    if (comments.Count() < 5)
                    {
                        if(comments.Count() == 0)
                        {
                            IsEmpty = true;
                        }

                        this.SubmitSeeMoreCommentCommand.Execute(commentPageUC);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });


            LoadedSubmitButtonCommand = new RelayCommand<Button>((btnSubmit) => { return true; }, (btnSubmit) => {
                btnSubmit.IsEnabled = false;
            });


            SubmitCommentButtonCommand = new RelayCommand<ProductDetailReviewPageUC>((productCommentUC) => { return true; }, async (productCommentUC) => {
                try
                {
                    Comment comment = new Comment();
                    comment.User.ID = Reviewer.Id.ToString();
                    comment.User.Name = Reviewer.Name;
                    comment.User.Avatar = Reviewer.Avatar;
                    comment.ProductID = ProductID;
                    comment.Content.Text = productCommentUC.txtComment.Text;

                    foreach (string pathImg in ImageUserCommentList)
                    {
                        comment.Content.ImageURLList.Add(Path.GetFileName(pathImg));
                    }

                    comment.Like = 0;
                    comment.Dislike = 0;
                    comment.CreatedAt = DateTime.Now;

                    switch(CommentType)
                    {
                        case "Game":
                            CommentDBHandler commentGameDB = new CommentDBHandler("Game");
                            bool isSuccess1 = await commentGameDB.InsertOneCommentsByTypeAsync(comment);

                            if (isSuccess1)
                            {
                                Console.WriteLine("Thêm comment thành công");
                            }
                            else
                            {
                                Console.WriteLine("Thêm comment thất bại");
                            }

                            break;

                        case "Computer":
                            CommentDBHandler commentComputerDB = new CommentDBHandler("Computer");
                            bool isSuccess2 = await commentComputerDB.InsertOneCommentsByTypeAsync(comment);

                            if (isSuccess2)
                            {
                                Console.WriteLine("Thêm comment thành công");
                            }
                            else
                            {
                                Console.WriteLine("Thêm comment thất bại");
                            }
                            break;

                        case "Movie":
                            CommentDBHandler commentMovieDB = new CommentDBHandler("Movie");
                            bool isSuccess3 = await commentMovieDB.InsertOneCommentsByTypeAsync(comment);

                            if (isSuccess3)
                            {
                                Console.WriteLine("Thêm comment thành công");
                            }
                            else
                            {
                                Console.WriteLine("Thêm comment thất bại");
                            }
                            break;

                        default:
                            break;
                    }

                    string currentDirectory = Directory.GetCurrentDirectory();
                    string binDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");

                    foreach (string sourceImg in ImageUserCommentList)
                    {
                        string resourceImg = binDirectory + Reviewer.Name + "\\Comment\\" + Path.GetFileName(sourceImg);
                        if (File.Exists(resourceImg))
                        {
                            continue;
                        }

                        File.Copy(sourceImg, resourceImg, true);
                    }

                    ImageUserCommentList.Clear();
                    productCommentUC.txtComment.Text = "";
                    productCommentUC.MediaContainer.Children.Clear();
                    productCommentUC.MediaControl.Visibility = Visibility.Collapsed;
                    productCommentUC.btnSubmit.IsEnabled = false;
                    productCommentUC.CommentContainer.Children.Clear();
                    LoadedCommentContainerCommand.Execute(productCommentUC);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                

            });


            SubmitMediaButtonCommand = new RelayCommand<ProductDetailReviewPageUC>((productCommentUC) => { return true; }, (productCommentUC) => {

                OpenFileDialog openfileDialog = new OpenFileDialog();
                openfileDialog.Filter = "Image files (*.jpg)|*.jpg| Video files (*.mp4)|*.mp4";
                openfileDialog.FilterIndex = 1;
                openfileDialog.Multiselect = true;
                openfileDialog.Title = "Chọn Ảnh | Video";

                if (openfileDialog.ShowDialog() == true)
                {
                    productCommentUC.btnSubmit.IsEnabled = true;
                    productCommentUC.MediaControl.Visibility = Visibility.Visible;
                    string fileExtension = Path.GetExtension(openfileDialog.FileName);

                    if (fileExtension == ".jpg")
                    {                        
                        ImageItemUC imageItem = new ImageItemUC();
                        imageItem.Image = new BitmapImage(new Uri(openfileDialog.FileName));
                        imageItem.Width = 110;
                        imageItem.Height = 110;
                        imageItem.Margin = new Thickness(10);
                        productCommentUC.MediaContainer.Children.Add(imageItem);
                        ImageUserCommentList.Add(openfileDialog.FileName);
                    }
                    //else if(fileExtension == ".mp4")
                    //{
                    //    ImageItemUC imageItem = new ImageItemUC();
                    //    imageItem.Image = new BitmapImage(new Uri(openfileDialog.FileName));
                    //    imageItem.Width = 110;
                    //    imageItem.Height = 110;
                    //    imageItem.Margin = new Thickness(10);
                    //    mediaContainer.Children.Add(imageItem);
                    //}

                }

            });

            SubmitCloseMediaButtonCommand = new RelayCommand<ProductDetailReviewPageUC>((productCommentUC) => { return true; }, (productCommentUC) => {
                productCommentUC.MediaControl.Visibility= Visibility.Collapsed;                
                productCommentUC.MediaContainer.Children.Clear();
                ImageUserCommentList.Clear();
                if (productCommentUC.txtComment.Text == "")
                {
                    productCommentUC.btnSubmit.IsEnabled = false;
                }

            });


            TextChangedCommentInputCommand = new RelayCommand<ProductDetailReviewPageUC>((productCommentUC) => { return true; }, (productCommentUC) => {
                if(productCommentUC.txtComment.Text == "" && productCommentUC.MediaControl.Visibility == Visibility.Collapsed)
                {
                    productCommentUC.btnSubmit.IsEnabled = false;
                }
                else
                {
                    productCommentUC.btnSubmit.IsEnabled = true;
                }
            });

            SubmitSeeMoreCommentCommand = new RelayCommand<ProductDetailReviewPageUC>((productCommentUC) => { return true; }, async (productCommentUC) => {
                
                CurrentPage++;
                CommentDBHandler commentDB = new CommentDBHandler(CommentType);

                try
                {
                    List<Comment> comments = await commentDB.GetCommentsByPageAsync(CurrentPage, ProductID,Reviewer.Id.ToString());
                    AmoutCommentCurrent += comments.Count();
                    if(comments.Count() == 0)
                    {
                        if (IsEmpty)
                        {
                            productCommentUC.emptyBox.Visibility = Visibility.Visible;
                        }
                        productCommentUC.btnSeeMore.Visibility = Visibility.Collapsed;
                        CurrentPage--;
                        return;
                    }

                    productCommentUC.emptyBox.Visibility = Visibility.Collapsed;

                    foreach (Comment comment in comments)
                    {
                        ProductCommentUC commentItem = new ProductCommentUC();
                        commentItem.Comment = comment;
                        commentItem.CommentType = CommentType;
                        commentItem.CommentContainer = productCommentUC.CommentContainer;


                        if (comment.User.ID == Reviewer.Id.ToString())
                        {
                            commentItem.IsCurrentUser = true;
                        }

                        productCommentUC.CommentContainer.Children.Add(commentItem);
                    }

                    if (AmoutCommentCurrent >= commentDB.GetCountDocumentByProductID(ProductID))
                    {
                        productCommentUC.btnSeeMore.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        productCommentUC.btnSeeMore.Visibility = Visibility.Visible;
                    }

                }
                catch (Exception ex)
                {

                }
            });

        }

    }
}
