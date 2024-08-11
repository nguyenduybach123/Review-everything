using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProducerLoginViewModel : BaseViewModel
    {
        
        public ICommand ChangeAccountTypeCommand { get; set; }

        public ICommand SubmitLoginAccountCommand { get; set; }

        public ProducerLoginViewModel() {

            ChangeAccountTypeCommand = new RelayCommand<UserControl>((uc) => { return true; },(uc) => {
                Window mainWindow = Window.GetWindow(uc);
                MainLoginViewModel mainLogin = mainWindow.DataContext as MainLoginViewModel;
                mainLogin.CurrentView = new ReviewerLoginViewModel();
            });

            SubmitLoginAccountCommand = new RelayCommand<ProducerLoginUC>((uc) => { return true; }, (uc) => {

                if (ValidationHandling.userLoginValidation(uc.txtUserName.Text, uc.txtPassword.Password))
                {
                    try
                    {
                        DB_SocialReviewDataContext db = new DB_SocialReviewDataContext();
                        PRODUCER_ACCOUNT account = db.PRODUCER_ACCOUNTs.Where(ac => ac.USERNAME.Equals(uc.txtUserName.Text) && ac.USERPASS.Equals(uc.txtPassword.Password)).FirstOrDefault();

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
                                MessageBox.Show("Chúc mừng bạn", "Đăng nhập thành công", MessageBoxButton.OK);
                                mainLoginContext.IsSuccessLogin = true;
                                mainLoginContext.UserID = account.USERID;
                                mainLoginContext.LoginType = MainLoginViewModel.UserType.Producer;
                                mainLoginWindow.Close();
                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Validation Error !!!");
                    }
                }
                else
                {
                    Console.WriteLine(" Value Validation Null or Empty !!!" + uc.txtUserName.Text);
                }

            });

        }

    }
}
