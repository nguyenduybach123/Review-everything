using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.View;
using Review_Project.MVVM.Model;


namespace Review_Project.MVVM.ViewModel
{
    public class ReviewerLoginViewModel : BaseViewModel
    {

        public ICommand ChangeAccountTypeCommand { get; set; }
        public ICommand SubmitLoginAccountCommand { get; set; }
        public ICommand SubmitRegisterButtonCommand { get; set; }

        public ReviewerLoginViewModel() {

            ChangeAccountTypeCommand = new RelayCommand<UserControl>((uc) => { return true; }, (uc) => {
                Window mainWindow = Window.GetWindow(uc);
                MainLoginViewModel mainLogin = mainWindow.DataContext as MainLoginViewModel;
                mainLogin.CurrentView = new ProducerLoginViewModel();
            });

            SubmitLoginAccountCommand = new RelayCommand<ReviewerLoginUC>((uc) => { return true; }, (uc) => {

                if (ValidationHandling.userLoginValidation(uc.txtUserName.Text, uc.txtPassword.Password))
                {
                    try
                    {
                        DB_SocialReviewDataContext db = new DB_SocialReviewDataContext();
                        REVIEWER_ACCOUNT account = db.REVIEWER_ACCOUNTs.Where(ac => ac.USERNAME.Equals(uc.txtUserName.Text) && ac.USERPASS.Equals(uc.txtPassword.Password)).FirstOrDefault();
                        
                        if (account != null)
                        {
                            Window mainLoginWindow = Window.GetWindow(uc);
                            MainLoginViewModel mainLoginContext = mainLoginWindow.DataContext as MainLoginViewModel;
                            if (mainLoginContext == null)
                            {
                                Console.WriteLine("Connect Login Fail !!!");
                            }
                            else
                            {
                                MessageBox.Show("Chúc mừng bạn", "Đăng nhập thành công", MessageBoxButton.OK, MessageBoxImage.Question);
                                mainLoginContext.IsSuccessLogin = true;
                                mainLoginContext.UserID = account.USERID;
                                mainLoginContext.LoginType = MainLoginViewModel.UserType.Reviewer;
                                mainLoginWindow.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên hoặc mật khẩu không hợp lệ", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Question);
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Validation Error !!!");
                    }
                }
                else {
                    Console.WriteLine(" Value Validation Null or Empty !!!" + uc.txtUserName.Text);
                }

            });


            SubmitRegisterButtonCommand = new RelayCommand<UserControl>((uc) => { return true; }, (uc) => {
                Register_Window registerWindow = new Register_Window();
                registerWindow.ShowDialog();
            });

        }
    }
}
