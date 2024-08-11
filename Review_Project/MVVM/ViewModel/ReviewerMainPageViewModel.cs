using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;
using Review_Project.MVVM.View;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using System.Windows.Input;
using System.Windows;


namespace Review_Project.MVVM.ViewModel
{
    public class ReviewerMainPageViewModel : ObservableObject
    {

        private object _currentView;

        public ProfileInfoViewModel ProfileVM;

        public ProductHomePageViewModel ProductHomePageVM;

        public ProductPostCreationPageViewModel ProductPostCreationVM;

        public ProductRankingPageViewModel ProductRankingVM;

        public ControlView controlViewPage_ProfilePage;

        public ControlView controlViewPage_ProductPage;

        public ControlView controlViewPage_PostPage;

        public ControlView controlViewPage_RankingPage;


        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedReviewerMainPageCommand { get; set; }
        public ICommand LoadProfileViewCommand { get; set; }
        public ICommand LoadProductHomePageCommand { get; set; }
        public ICommand LoadPostCreationPageCommand { get; set; }
        public ICommand LoadRankingPageCommand { get; set; }
        public ICommand LoadLogOutCommand { get; set; }

        public bool isLoaded = false;

        public ReviewerMainPageViewModel()
        {

            ProfileVM = new ProfileInfoViewModel();
            ProductHomePageVM = new ProductHomePageViewModel();
            ProductPostCreationVM = new ProductPostCreationPageViewModel();

            controlViewPage_ProfilePage = new ControlView();
            controlViewPage_ProfilePage.Push<ProfileInfoViewModel>(ProfileVM);

            controlViewPage_ProductPage = new ControlView();
            controlViewPage_ProductPage.Push<ProductHomePageViewModel>(ProductHomePageVM);

            controlViewPage_PostPage = new ControlView();
            controlViewPage_PostPage.Push<ProductPostCreationPageViewModel>(ProductPostCreationVM);

            controlViewPage_RankingPage = new ControlView();
            controlViewPage_RankingPage.Push<ProductRankingPageViewModel>(ProductRankingVM);

            LoadedReviewerMainPageCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                isLoaded = true;
                object lastViewPage = null;
                controlViewPage_ProfilePage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadProfileViewCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_ProfilePage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadProductHomePageCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_ProductPage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadPostCreationPageCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_PostPage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadRankingPageCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_RankingPage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadLogOutCommand = new RelayCommand<ReviewerMainPageUC>((reviewerMainUC) => { return true; }, (reviewerMainUC) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc sẽ đăng xuất", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                    MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                    CurrentView = null;
                    controlViewPage_ProfilePage.Clear();
                    controlViewPage_PostPage.Clear();
                    controlViewPage_ProductPage.Clear();
                    controlViewPage_RankingPage.Clear();
                    ProfileVM = null;
                    ProductHomePageVM = null;
                    ProductPostCreationVM = null;

                    mainWindowVM.ProducerUser = null;
                    mainWindowVM.ReviewerUser = null;
                    mainWindowVM.CurrentView = null;
                    mainWindowVM.LoadedWindowCommand.Execute(mainWindow);
                }
            });

        }

    }
}

