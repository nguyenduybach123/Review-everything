using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace Review_Project.MVVM.ViewModel
{
    public class ProducerProductPageViewModel : BaseViewModel
    {
        public ProducerMainPageViewModel MainPage { get; set; }
        public Producer User { get; set; }
        public ICommand LoadProducerProductPageCommand { get; set; }
        public ICommand LoadComboboxCategoryCommand { get; set; }
        public ICommand SelectionChangedCbxCategoryCommand { get; set; }
        public ICommand TextChangedtxtSearchCommand { get; set; }
        public ProducerProductPageViewModel()
        {
            LoadProducerProductPageCommand = new RelayCommand<ProducerProductPageUC>((producerProductUC) => { return true; }, async (producerProductUC) => {
                try
                {
                    Window mainWindow = Window.GetWindow(producerProductUC);
                    MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;
                    User = mainWindowVM.ProducerUser;

                    ProductVMDBHandler db = new ProductVMDBHandler();
                    List<ProductVM> productVMs = await db.GetProductListByProducerIDAsnyc(User.Id.ToString());

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productVMs)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    producerProductUC.productContainer.ItemsSource = productVMs;

                }
                catch (Exception ex)
                {
                    return;
                }
            });


            LoadComboboxCategoryCommand = new RelayCommand<ProducerProductPageUC>((producerProductUC) => { return true; }, async (producerProductUC) => {
                using (DB_SocialReviewDataContext db = new DB_SocialReviewDataContext())
                {
                    List<PRODUCT_CATEGORY> categoryList = db.PRODUCT_CATEGORies.ToList();

                    PRODUCT_CATEGORY categoryAll = new PRODUCT_CATEGORY();
                    categoryAll.CATEGORY_NAME = "Tất Cả";
                    categoryAll.CATEGORY_CODE = "tất cả";
                    categoryList.Insert(0, categoryAll);

                    producerProductUC.cbxCategory.ItemsSource = categoryList;
                    producerProductUC.cbxCategory.DisplayMemberPath = "CATEGORY_NAME";
                    producerProductUC.cbxCategory.SelectedValuePath = "CATEGORY_CODE";

                    producerProductUC.cbxCategory.SelectedIndex = 0;
                }
            });

            SelectionChangedCbxCategoryCommand = new RelayCommand<ProducerProductPageUC>((producerProductUC) => { return true; }, async (producerProductUC) => {
                try
                {
                    PRODUCT_CATEGORY categorySelected = producerProductUC.cbxCategory.SelectedItem as PRODUCT_CATEGORY;

                    if (categorySelected == null)
                        return;

                    ProductVMDBHandler db = new ProductVMDBHandler();
                    List<ProductVM> productVMs = await db.GetProductListByProducerAndCategoryAndProducerIDAsync(User.Id.ToString(), categorySelected.CATEGORY_CODE, producerProductUC.txtSearch.Text);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productVMs)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    producerProductUC.productContainer.ItemsSource = productVMs;
                    return;
                }
                catch(Exception ex) { 
                    Console.WriteLine(ex.Message);
                }
            });

            TextChangedtxtSearchCommand = new RelayCommand<ProducerProductPageUC>((producerProductUC) => { return true; }, async (producerProductUC) => {
                try
                {
                    PRODUCT_CATEGORY categorySelected = producerProductUC.cbxCategory.SelectedItem as PRODUCT_CATEGORY;

                    if (categorySelected == null)
                        return;

                    ProductVMDBHandler db = new ProductVMDBHandler();
                    List<ProductVM> productVMs = await db.GetProductListByProducerAndCategoryAndProducerIDAsync(User.Id.ToString(), categorySelected.CATEGORY_CODE, producerProductUC.txtSearch.Text);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productVMs)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    producerProductUC.productContainer.ItemsSource = productVMs;
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

        }

        public async void ProductItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border itemContainer = sender as Border;
            ProductVM product = itemContainer.DataContext as ProductVM;

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

            if (mainWindowVM.CurrentView is ProducerMainPageViewModel producerMainUC)
            {

                

                ProductAnalyticsViewModel productAnalyticsVM = new ProductAnalyticsViewModel();

                if (product.Type.typeId == "game")
                {
                    Product_GameDBHandler db = new Product_GameDBHandler();
                    productAnalyticsVM.Product = await db.GetProductToIDAsync(product.productID);
                }
                else if (product.Type.typeId == "computer")
                {
                    Product_ComputerDBHandler db = new Product_ComputerDBHandler();
                    productAnalyticsVM.Product = await db.GetProductToIDAsync(product.productID);
                }
                else if (product.Type.typeId == "movie")
                {
                    Product_MovieDBHandler db = new Product_MovieDBHandler();
                    productAnalyticsVM.Product = await db.GetProductToIDAsync(product.productID);
                }

                productAnalyticsVM.MainPage = MainPage;

                MainPage.controlViewPage_MyProductPage.Push<ProductAnalyticsViewModel>(productAnalyticsVM);

                object lastViewPage = null;
                MainPage.controlViewPage_MyProductPage.getLastViewPage(ref lastViewPage);
                MainPage.CurrentView = lastViewPage;
            }

        }

    }
}
