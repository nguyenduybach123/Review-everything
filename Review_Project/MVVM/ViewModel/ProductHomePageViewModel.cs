using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductHomePageViewModel : ObservableObject
    {
        public List<PRODUCT_CATEGORY> Categories { get; set; }
        public PRODUCT_CATEGORY CurrentCategory { get; set; }

        public ICommand LoadProductHomePageCommand { get; set; }
        public ICommand LoadCombobox_Category_Command { get; set; }
        public ICommand SeletionChangedCombobox_Category_Command { get; set; }
        public ICommand TextChangedSearchBarCommand { get; set; }

        private object _currentPage;

        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        private Boolean isSelectCbxFirstTime = false;

        public ProductHomePageViewModel()
        {

            LoadProductHomePageCommand = new RelayCommand<ProductHomePageUC>((productHomePageUC) => { return true; }, async (productHomePageUC) => {
                try
                {
                    CurrentPage = new ProductOverviewPageUC();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR ERROR ERROR !!!!! : /n" + ex);
                }
            });


            LoadCombobox_Category_Command = new RelayCommand<ComboBox>((cbxCategory) => { return true; }, async (cbxCategory) => {
                try
                {
                    DB_SocialReviewDataContext db = new DB_SocialReviewDataContext();
                    Categories = db.PRODUCT_CATEGORies.ToList();

                    PRODUCT_CATEGORY categoryAll = new PRODUCT_CATEGORY();
                    categoryAll.CATEGORY_NAME = "Tất Cả";
                    categoryAll.CATEGORY_CODE = "tất cả";
                    Categories.Insert(0, categoryAll);

                    cbxCategory.ItemsSource = Categories;
                    cbxCategory.DisplayMemberPath = "CATEGORY_NAME";
                    cbxCategory.SelectedValuePath = "CATEGORY_CODE";

                    cbxCategory.SelectedIndex = 0;
                    CurrentCategory = categoryAll;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR ERROR ERROR !!!!! : /n" + ex);
                }
            });


            SeletionChangedCombobox_Category_Command = new RelayCommand<ComboBox>((cbxCategory) => { return true; }, async (cbxCategory) => {
                try
                {
                    if (!isSelectCbxFirstTime) {
                        ProductCategorysPageViewModel productCategorysPageVM = new ProductCategorysPageViewModel();
                        productCategorysPageVM.Category = CurrentCategory;
                        productCategorysPageVM.SearchString = "";
                        CurrentPage = productCategorysPageVM;
                        isSelectCbxFirstTime = true;
                    }

                    if (CurrentPage is ProductCategorysPageViewModel categoryPageUC)
                    {
                        CurrentCategory = (PRODUCT_CATEGORY)cbxCategory.SelectedItem;
                        categoryPageUC.Category = CurrentCategory;
                        categoryPageUC.LoadListProductCommand.Execute(categoryPageUC.ProductItems);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR ERROR ERROR !!!!! : /n" + ex);
                }
            });


            TextChangedSearchBarCommand = new RelayCommand<ProductHomePageUC>((productHomePageUC) => { return true; }, async (productHomePageUC) =>
            {
                try
                {

                    if (!isSelectCbxFirstTime)
                    {
                        ProductCategorysPageViewModel productCategorysPageVM = new ProductCategorysPageViewModel();
                        productCategorysPageVM.Category = CurrentCategory;
                        productCategorysPageVM.SearchString = "";
                        CurrentPage = productCategorysPageVM;
                        isSelectCbxFirstTime = true;
                    }

                    if (CurrentPage is ProductCategorysPageViewModel categoryPageUC)
                    {
                        categoryPageUC.SearchString = productHomePageUC.txtSearchBar.Text;
                        categoryPageUC.LoadListProductCommand.Execute(categoryPageUC.ProductItems);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR ERROR ERROR !!!!! : /n" + ex);
                }
            });

        }
    }
}
