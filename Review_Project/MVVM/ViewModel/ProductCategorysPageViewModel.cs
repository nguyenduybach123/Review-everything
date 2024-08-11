using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductCategorysPageViewModel : ObservableObject
    {   
        private PRODUCT_CATEGORY _category;
        public PRODUCT_CATEGORY Category 
        {
            get { return _category; }
        
            set { 
                _category = value; 
                OnPropertyChanged("_category");
            }
        }

        public string _searchString;

        public string SearchString
        {
            get { return _searchString; }
            set 
            { 
                _searchString = value;
                OnPropertyChanged("SearchString");
            }
        }
        public ItemsControl ProductItems { get; set; }

        public int PosCurrent { get; set; }
        public List<ProductVM> productVMList { get; set; }

        public ICommand LoadProductCategoryPageCommand { get; set; }
        public ICommand LoadListProductCommand { get; set; }
        public ICommand ClickProductItemCommand { get; set; }
        public ProductCategorysPageViewModel()
        {
            PosCurrent = 10;

            LoadProductCategoryPageCommand = new RelayCommand<ProductCategoryPageUC>((categoryPageUC) => { return true; }, async (categoryPageUC) =>
            {
                try
                {
                    ProductItems = categoryPageUC.listProductVM;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });


            LoadListProductCommand = new RelayCommand<ItemsControl>((listProduct) => { return true; }, async (listProduct) =>
            {
                try
                {
                    if (listProduct == null)
                        return;

                    ProductVMDBHandler productVMDB = new ProductVMDBHandler();
                    productVMList = (List<ProductVM>)await productVMDB.GetProductByCategoryAndSearchStringAsync(PosCurrent, Category.CATEGORY_CODE,SearchString);

                    string fullDirectory = Path.GetFullPath("..//..//Images//");
                    foreach (ProductVM product in productVMList)
                    {
                        string userImg = fullDirectory + "User\\Reviewer" + product.Producer.Name + "\\Avatar\\" + product.Producer.avatar;
                        product.Producer.avatar = userImg;

                        string productImg = fullDirectory + "Product\\" + product.Name + "\\" + product.Avatar;
                        product.Avatar = productImg;
                    }

                    listProduct.ItemsSource = productVMList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

        }

        public void ProductItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Border itemContainer = sender as Border;
            ProductVM product = itemContainer.DataContext as ProductVM;

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

            if(mainWindowVM.CurrentView is ReviewerMainPageViewModel reviewerMainVM)
            {
                ProductInfoDetailViewModel productInfoDetailVM = new ProductInfoDetailViewModel();
                productInfoDetailVM.SetProductType(product.Type.typeId);
                productInfoDetailVM.ProductID = product.productID;
                reviewerMainVM.controlViewPage_ProductPage.Push<ProductInfoDetailViewModel>(productInfoDetailVM);

                object lastViewPage = null;
                reviewerMainVM.controlViewPage_ProductPage.getLastViewPage(ref lastViewPage);
                reviewerMainVM.CurrentView = lastViewPage;
            }
            
        }
    }
}
