using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;
using System.Windows;
using MongoDB.Driver;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductCommentItemViewModel : BaseViewModel
    {
        public Comment Comment { get; set; }
        public string CurrentContent { get; set; }

        public ICommand LoadedCommentItemCommand { get; set; }
        public ICommand SubmitRemoveCommentCommand { get; set; }
        public ICommand OpenUpdateBarCommentCommand { get; set; }
        public ICommand SubmitCancelUpdateCommentCommand { get; set; }
        public ICommand SubmitUpdateCommentCommand { get; set; }
        public ProductCommentItemViewModel()
        {
            LoadedCommentItemCommand = new RelayCommand<ProductCommentUC>((productCommentUC) => { return true; }, async (productCommentUC) =>
            {
                Comment = productCommentUC.Comment;
                productCommentUC.userName.Text = Comment.User.Name;

                string avatarDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//" + Comment.User.Name + "//Avatar//" + Comment.User.Avatar);
                productCommentUC.userImg.ImageSource = new BitmapImage(new Uri(avatarDirectory));

                productCommentUC.commentDate.Text = Comment.CreatedAt.ToString();
                CurrentContent = Comment.Content.Text;
                productCommentUC.commentContent.Text = Comment.Content.Text;

                foreach (string pathImg in Comment.Content.ImageURLList)
                {
                    ImageItemUC imageItemUC = new ImageItemUC();
                    string commentDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//" + Comment.User.Name + "//Comment//" + pathImg);
                    imageItemUC.Image = new BitmapImage(new Uri(commentDirectory));
                    productCommentUC.MediaContainer.Children.Add(imageItemUC);
                }

                if (!productCommentUC.IsCurrentUser)
                {
                    productCommentUC.commentSelecteBar.Visibility = Visibility.Collapsed;
                }

            });

            SubmitRemoveCommentCommand = new RelayCommand<ProductCommentUC>((productCommentUC) => { return true; }, async (productCommentUC) =>
            {
                try
                {

                    CommentDBHandler commentDB = new CommentDBHandler(productCommentUC.CommentType);
                    DeleteResult result = await commentDB.DeleteOneCommentsByTypeAsync(Comment.Id);
                    if (result != null && result.DeletedCount > 0)
                    {
                        Console.WriteLine("Xóa thành công");
                    }
                    else
                    {
                        Console.WriteLine("Xóa thất bại");
                    }

                    productCommentUC.CommentContainer.Children.Remove(productCommentUC);
                    productCommentUC = null;

                    //foreach(string pathImg in Comment.Content.ImageURLList)
                    //{
                    //    string commentDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//" + Comment.User.Name + "//Comment//" + pathImg);
                    //    if (File.Exists(commentDirectory))
                    //    {
                    //        File.Delete(commentDirectory);
                    //    }
                    //}

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(Comment);
            });

            OpenUpdateBarCommentCommand = new RelayCommand<ProductCommentUC>((productCommentUC) => { return true; }, async (productCommentUC) => {
                productCommentUC.commentUpdateBar.Visibility = Visibility.Visible;
                productCommentUC.commentContent.IsReadOnly = false;

            });

            SubmitCancelUpdateCommentCommand = new RelayCommand<ProductCommentUC>((productCommentUC) => { return true; }, async (productCommentUC) => {
                productCommentUC.commentUpdateBar.Visibility = Visibility.Collapsed;
                productCommentUC.commentContent.IsReadOnly = true;
                productCommentUC.commentContent.Text = CurrentContent;
            });

            SubmitUpdateCommentCommand = new RelayCommand<ProductCommentUC>((productCommentUC) => { return true; }, async (productCommentUC) => {
                try
                {
                    CommentDBHandler commentDB = new CommentDBHandler(productCommentUC.CommentType);
                    UpdateResult result = await commentDB.UpdateOneCommentsByTypeAsync(Comment.Id, productCommentUC.commentContent.Text);
                    if(result.ModifiedCount > 0)
                    {
                        CurrentContent = productCommentUC.commentContent.Text;
                        Console.WriteLine("Sửa thành công");
                    }
                    else
                    {
                        Console.WriteLine("Sửa thất bại");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                productCommentUC.commentUpdateBar.Visibility = Visibility.Collapsed;
                productCommentUC.commentContent.IsReadOnly = true;
            });


        }


    }
}
