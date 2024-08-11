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
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProducerMainPageViewModel : ObservableObject
    {
        private object _currentView;

        public ProducerProfileInfoViewModel ProducerProfile_PageVM;

        public ProductCreationPageViewModel ProductCreationPageVM;
        
        public ProducerProductPageViewModel ProducerProductPageVM;


        public ControlView controlViewPage_ProfilePage;

        public ControlView controlViewPage_ProductCreationPage;

        public ControlView controlViewPage_MyProductPage;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadedProducerMainPageCommand { get; set; }
        public ICommand LoadProfileViewCommand { get; set; }
        public ICommand LoadProductCreationPageCommand { get; set; }
        public ICommand LoadMyProductPageCommand { get; set; }
        public ICommand LoadLogOutCommand { get; set; }

        public bool isLoaded = false;

        public ProducerMainPageViewModel()
        {
            ProducerProfile_PageVM = new ProducerProfileInfoViewModel();
            ProductCreationPageVM = new ProductCreationPageViewModel();
            ProducerProductPageVM = new ProducerProductPageViewModel();
            ProducerProductPageVM.MainPage = this;

            controlViewPage_ProfilePage = new ControlView();
            controlViewPage_ProfilePage.Push<ProducerProfileInfoViewModel>(ProducerProfile_PageVM);

            controlViewPage_ProductCreationPage = new ControlView();
            controlViewPage_ProductCreationPage.Push<ProductCreationPageViewModel>(ProductCreationPageVM);

            controlViewPage_MyProductPage = new ControlView();
            controlViewPage_MyProductPage.Push<ProducerProductPageViewModel>(ProducerProductPageVM);

            LoadedProducerMainPageCommand = new RelayCommand<ProducerMainPageUC>((producerMainUC) => { return true; }, (producerMainUC) =>
            {
                isLoaded = true;
                object lastViewPage = null;
                controlViewPage_ProfilePage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
                producerMainUC.MainView.Width = 1000;
            });

            LoadProfileViewCommand = new RelayCommand<ProducerMainPageUC>((producerMainUC) => { return true; }, (producerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_ProfilePage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
                producerMainUC.MainView.Width = 1000;
            });

            LoadProductCreationPageCommand = new RelayCommand<ProducerMainPageUC>((producerMainUC) => { return true; }, (producerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_ProductCreationPage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
                producerMainUC.MainView.HorizontalAlignment = HorizontalAlignment.Center;
                producerMainUC.MainView.VerticalAlignment = VerticalAlignment.Center;
                producerMainUC.MainView.Width = 1000;
            });

            LoadMyProductPageCommand = new RelayCommand<ProducerMainPageUC>((producerMainUC) => { return true; }, (producerMainUC) =>
            {
                object lastViewPage = null;
                controlViewPage_MyProductPage.getLastViewPage(ref lastViewPage);
                CurrentView = lastViewPage;
            });

            LoadLogOutCommand = new RelayCommand<ProducerMainPageUC>((producerMainUC) => { return true; }, (producerMainUC) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc sẽ đăng xuất", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                    MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                    CurrentView = null;
                    controlViewPage_ProfilePage.Clear();
                    controlViewPage_ProductCreationPage.Clear();
                    controlViewPage_MyProductPage.Clear();
                    ProductCreationPageVM = null;
                    ProducerProductPageVM = null;

                    mainWindowVM.ProducerUser = null;
                    mainWindowVM.ReviewerUser = null;
                    mainWindowVM.CurrentView = null;
                    mainWindowVM.LoadedWindowCommand.Execute(mainWindow);
                }
            });

        }
    }
}

