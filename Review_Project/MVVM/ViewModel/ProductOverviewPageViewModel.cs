using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductOverviewPageViewModel : BaseViewModel
    {
        public enum OverviewType
        {
            New,
            MoreView,
            Hot
        }

        public OverviewType CurrentOverviewType;

        public List<ProductVM> productList;

        public static int LimitForPage = 10;

        public int CurrentPage = 1;

        public ICommand LoadProductOverviewPageCommand { get; set; }
        public ICommand ClickProductItemCommand { get; set; }
        public ICommand SelectedNewProductCommand { get; set; }
        public ICommand SelectedMoreViewProductCommand { get; set; }
        public ICommand SelectedHotProductCommand { get; set; }
        public ICommand SubmitSeeMoreButtonCommand { get; set; }
        public ProductOverviewPageViewModel()
        {

            LoadProductOverviewPageCommand = new RelayCommand<ProductOverviewPageUC>((overviewPageUC) => { return true; }, async (overviewPageUC) =>
            {
                try
                {
                    CurrentOverviewType = OverviewType.New;
                    ProductVMDBHandler productVM = new ProductVMDBHandler();
                    productList = (List<ProductVM>)await productVM.GetNewProductAsync(LimitForPage, CurrentPage);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productList)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    overviewPageUC.listProductVM.ItemsSource = productList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lấy sản phẩm thất bại !!!");
                    Console.WriteLine(ex.Message);
                }

            });

            SelectedNewProductCommand = new RelayCommand<ProductOverviewPageUC>((overviewPageUC) => { return true; }, async (overviewPageUC) => {
                try
                {
                    CurrentPage = 1;
                    CurrentOverviewType = OverviewType.New;
                    overviewPageUC.listProductVM.ItemsSource = null;
                    ProductVMDBHandler productVM = new ProductVMDBHandler();
                    productList = (List<ProductVM>)await productVM.GetNewProductAsync(LimitForPage, CurrentPage);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productList)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    overviewPageUC.listProductVM.ItemsSource = productList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lấy sản phẩm thất bại !!!");
                    Console.WriteLine(ex.Message);
                }
            });

            SelectedMoreViewProductCommand = new RelayCommand<ProductOverviewPageUC>((overviewPageUC) => { return true; }, async (overviewPageUC) => {
                try
                {
                    CurrentPage = 1;
                    CurrentOverviewType = OverviewType.MoreView;
                    overviewPageUC.listProductVM.ItemsSource = null;
                    ProductVMDBHandler productVM = new ProductVMDBHandler();
                    productList = (List<ProductVM>)await productVM.GetProductForViewAsync(LimitForPage,CurrentPage);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productList)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    overviewPageUC.listProductVM.ItemsSource = productList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lấy sản phẩm thất bại !!!");
                    Console.WriteLine(ex.Message);
                }
            });

            SelectedHotProductCommand = new RelayCommand<ProductOverviewPageUC>((overviewPageUC) => { return true; }, async (overviewPageUC) => {
                try
                {
                    CurrentPage = 1;
                    CurrentOverviewType = OverviewType.Hot;
                    overviewPageUC.listProductVM.ItemsSource = null;
                    ProductVMDBHandler productVM = new ProductVMDBHandler();
                    productList = (List<ProductVM>)await productVM.GetProductForHotAsync(LimitForPage, CurrentPage);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productList)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    overviewPageUC.listProductVM.ItemsSource = productList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lấy sản phẩm thất bại !!!");
                    Console.WriteLine(ex.Message);
                }
            });

            SubmitSeeMoreButtonCommand = new RelayCommand<ProductOverviewPageUC>((overviewPageUC) => { return true; }, async (overviewPageUC) => {
                switch (CurrentOverviewType)
                {
                    case OverviewType.New:
                        break;

                    case OverviewType.MoreView:
                        break;

                    case OverviewType.Hot:
                        break;

                    default:
                        break;
                }
            });

        }

        public void ProductItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Border itemContainer = sender as Border;
            ProductVM product = itemContainer.DataContext as ProductVM;

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

            if(mainWindowVM.CurrentView is ReviewerMainPageViewModel reviewerMainUC)
            {
                ProductInfoDetailViewModel productInfoDetailVM = new ProductInfoDetailViewModel();
                productInfoDetailVM.SetProductType(product.Type.typeId);
                productInfoDetailVM.ProductID = product.productID;
                reviewerMainUC.controlViewPage_ProductPage.Push<ProductInfoDetailViewModel>(productInfoDetailVM);

                object lastViewPage = null;
                reviewerMainUC.controlViewPage_ProductPage.getLastViewPage(ref lastViewPage);
                reviewerMainUC.CurrentView = lastViewPage;
            }

        }


    }
}
