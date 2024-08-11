using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;
using Review_Project.MVVM.View;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using System.Windows.Input;
using System.Windows;

namespace Review_Project.MVVM.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public Reviewer ReviewerUser { get; set; }
        public Producer ProducerUser { get; set; }

        public ICommand LoadedWindowCommand { get; set; }
        public MainWindowViewModel()
        {
            LoadedWindowCommand = new RelayCommand<MainWindow>((mainWindow) => { return true; }, async (mainWindow) => {
                
                mainWindow.Hide();
                Login_Window loginWindow = new Login_Window();
                MainLoginViewModel loginWindowContext = loginWindow.DataContext as MainLoginViewModel;
                loginWindow.ShowDialog();

                if (loginWindow.IsActive == false && loginWindowContext.IsSuccessLogin == false)
                    mainWindow.Close();


                if (loginWindowContext.IsSuccessLogin == true)
                {
                    //Nếu đăng nhập thành công thì lấy thông tin người dùng
                    if(loginWindowContext.LoginType == MainLoginViewModel.UserType.Reviewer)
                    {
                        ReviewerUser = await GetReviewerInfo(loginWindowContext.UserID);
                        CurrentView = new ReviewerMainPageViewModel();
                    }
                    else
                    {
                        ProducerUser = await GetProducerInfo(loginWindowContext.UserID);
                        CurrentView = new ProducerMainPageViewModel();
                    }

                    mainWindow.Show();
                }


            });

        }

        private async Task<Reviewer> GetReviewerInfo(string userID)
        {
            try
            {
                ReviewerDBHandler reviewerDB = new ReviewerDBHandler();
                Reviewer reviewer = await reviewerDB.GetUserReviewerAsync(userID);
                return reviewer;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lấy thông tin người dùng thất bại");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task<Producer> GetProducerInfo(string userID)
        {
            try
            {
                ProducerDBHandler producerDB = new ProducerDBHandler();
                Producer producer = await producerDB.GetUserProducerAsync(userID);
                return producer;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lấy thông tin người dùng thất bại");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
