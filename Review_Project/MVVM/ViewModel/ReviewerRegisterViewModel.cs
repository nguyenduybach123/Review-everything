using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ReviewerRegisterViewModel : BaseViewModel
    {
        public ICommand SubmitUserRegisterCommand { get; set; }
        public ICommand SubmitButtonMediaAvatarCommand { get; set; }
        public ReviewerRegisterViewModel()
        {
            SubmitUserRegisterCommand = new RelayCommand<ReviewerRegisterUC>((reviewerRegisterUC) => { return true; }, async (reviewerRegisterUC) =>
            {
                try
                {
                    ValidationHandling.TextValidate validate = ValidationHandling.textValuesValidation(reviewerRegisterUC.txtHoten.Text, reviewerRegisterUC.txtGmail.Text);

                    if (validate == ValidationHandling.TextValidate.NullOrEmpty || reviewerRegisterUC.userImg.ImageSource == null)
                    {
                        MessageBox.Show("Yêu cầu nhập dữ liệu đầy đủ", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    // Khởi tạo reviewer
                    Reviewer reviewer = new Reviewer();
                    reviewer.Avatar = reviewerRegisterUC.userImg.ImageSource.ToString();
                    if (reviewerRegisterUC.userImg.ImageSource is BitmapImage bitmapImage)
                    {
                        Uri uriSource = bitmapImage.UriSource;

                        if (uriSource != null)
                        {
                            string fileName = Path.GetFileName(uriSource.LocalPath);
                            reviewer.Avatar = fileName;
                        }
                    }

                    reviewer.Name = reviewerRegisterUC.txtHoten.Text;
                    reviewer.Gmail = reviewerRegisterUC.txtGmail.Text;


                    // Khởi tạo tài khoản reviewer
                    REVIEWER_ACCOUNT reviewerAccount = new REVIEWER_ACCOUNT();
                    reviewerAccount.USERNAME = reviewerRegisterUC.txtUsername.Text;
                    reviewerAccount.USERPASS = reviewerRegisterUC.txtPassword.Password;
                    reviewerAccount.GMAIL = reviewerRegisterUC.txtGmail.Text;
                    reviewerAccount.PHONE = reviewerRegisterUC.txtPhone.Text;
                    reviewerAccount.DATE_CREATED = DateTime.Now;

                    if (!ValidationHandling.reviewerAccountValidation(reviewerAccount))
                    {
                        reviewer = null;
                        reviewerAccount = null;
                        return;
                    }

                    bool isReviewerValid = await ValidationHandling.reviewerUserValidation(reviewer);
                    if (!isReviewerValid)
                    {
                        reviewer = null;
                        reviewerAccount = null;
                        return;
                    }


                    // Tạo reviewer trong mongodb
                    ReviewerDBHandler reviewerDB = new ReviewerDBHandler();
                    int insertResutl = await reviewerDB.CreateUserReviewerAsync(reviewer);

                    if (insertResutl == -1)
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong lúc tạo người dùng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        reviewer = null;
                        reviewerAccount = null;
                        return;
                    }
                    else if (insertResutl == 0)
                    {
                        MessageBox.Show("Trùng tên người dùng", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                        reviewer = null;
                        reviewerAccount = null;
                        return;

                    }

                    // Tạo tài khoản reviewer sql
                    using (DB_SocialReviewDataContext db = new DB_SocialReviewDataContext())
                    {
                        reviewerAccount.USERID = reviewer.Id.ToString();
                        db.REVIEWER_ACCOUNTs.InsertOnSubmit(reviewerAccount);
                        db.SubmitChanges();
                        
                    }

                    // Khởi tạo nên lưu trữ
                    bool isSucess = CreateUserDirectory(reviewerRegisterUC.txtHoten.Text);

                    if (!isSucess)
                    {
                        MessageBox.Show("Tạo lưu trữ dữ liệu người dùng thất bại", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                        reviewer = null;
                        reviewerAccount = null;
                        return;
                    }

                    // Lưu Avatar vào thư mục avatar của người dùng
                    string fullDirectory = Path.GetFullPath("..//..//Images//User//Reviewer//");
                    string resourceImg = fullDirectory + reviewer.Name + "\\Avatar\\" + reviewer.Avatar;
                    if (reviewerRegisterUC.userImg.ImageSource is BitmapImage bitMapImage)
                    {
                        Uri uriSource = bitMapImage.UriSource;

                        if (uriSource != null)
                        {
                            string imagePath = uriSource.LocalPath;
                            File.Copy(imagePath, resourceImg, true);
                        }
                    
                    }

                    MessageBox.Show("Tạo người thành công", "Thành Công", MessageBoxButton.OK, MessageBoxImage.Information);

                    reviewerRegisterUC.txtGmail.Text = "";
                    reviewerRegisterUC.txtHoten.Text = "";
                    reviewerRegisterUC.txtPhone.Text = "";
                    reviewerRegisterUC.txtUsername.Text = "";
                    reviewerRegisterUC.txtPassword.Password = "";
                    reviewerRegisterUC.userImg.ImageSource = null;

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        MessageBox.Show("Dữ liệu đã tồn tại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo người dùng thất bại", "Thất Bại", MessageBoxButton.OK, MessageBoxImage.Information);
                    Console.WriteLine(ex.Message);
                }
            });


            SubmitButtonMediaAvatarCommand = new RelayCommand<ReviewerRegisterUC>((reviewerRegisterUC) => { return true; }, (reviewerRegisterUC) =>{
                OpenFileDialog openfileDialog = new OpenFileDialog();
                openfileDialog.Filter = "Image files (*.jpg)|*.jpg";
                openfileDialog.FilterIndex = 1;
                openfileDialog.Multiselect = true;
                openfileDialog.Title = "Chọn Avatar";

                if (openfileDialog.ShowDialog() == true)
                {
                    string fileExtension = Path.GetExtension(openfileDialog.FileName);

                    if (fileExtension == ".jpg")
                    {
                        reviewerRegisterUC.userImg.ImageSource = new BitmapImage(new Uri(openfileDialog.FileName)); 
                    }

                }
            });

        }


        private bool CreateUserDirectory(string folderName)
        {
            string fullPathDirectory = Path.GetFullPath("..//..//");

            string folderPathImageUser = fullPathDirectory + "Images\\User\\Reviewer\\" + folderName;

            string folderPathPostUser = fullPathDirectory + "Posts\\Reviewer\\" + folderName;

            try
            {
                if (!Directory.Exists(folderPathImageUser) && !Directory.Exists(folderPathPostUser))
                {
                    Directory.CreateDirectory(folderPathImageUser);

                    string folderPathImageUserAvatar = folderPathImageUser + "\\Avatar";
                    string folderPathImageUserComment = folderPathImageUser + "\\Comment";
                    string folderPathImageUserPost = folderPathImageUser + "\\Post";
                    if (Directory.Exists(folderPathImageUser))
                    {
                        Directory.CreateDirectory(folderPathImageUserAvatar);
                        Directory.CreateDirectory(folderPathImageUserComment);
                        Directory.CreateDirectory(folderPathImageUserPost);
                    }


                    Directory.CreateDirectory(folderPathPostUser);

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
