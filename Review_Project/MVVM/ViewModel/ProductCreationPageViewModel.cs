using System;
using System.Collections.Generic;
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
    public class ProductCreationPageViewModel : BaseViewModel
    {
        private List<string> ImagePathList;
        private Producer ProducerUser;

        public ICommand LoadProductCreationPageCommand { get; set; }
        public ICommand LoadComboboxCategoryCommand { get; set; }
        public ICommand OpenDialogMeidaCommand { get; set; }
        public ICommand SubmitButtonCloseCommand { get; set; }
        public ICommand SubmitButtonCreationProductCommand { get; set; }
        public ProductCreationPageViewModel()
        {
            LoadProductCreationPageCommand = new RelayCommand<ProductCreationPageUC>((productCreationUC) => { return true; }, (productCreationUC) => {

                Window mainWindow = Window.GetWindow(productCreationUC);
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                ImagePathList = new List<string>();
                ProducerUser = mainWindowVM.ProducerUser;
            });

            LoadComboboxCategoryCommand = new RelayCommand<ProductCreationPageUC>((productCreationUC) => { return true; }, (productCreationUC) => {
                using(DB_SocialReviewDataContext db = new DB_SocialReviewDataContext())
                {
                    List<PRODUCT_CATEGORY> categoryList = db.PRODUCT_CATEGORies.ToList();
                    productCreationUC.cbxCategoryType.ItemsSource = categoryList;
                    productCreationUC.cbxCategoryType.DisplayMemberPath = "CATEGORY_NAME";
                    productCreationUC.cbxCategoryType.SelectedValuePath = "CATEGORY_CODE";
                    productCreationUC.cbxCategoryType.SelectedIndex = 0;
                }
            });

            SubmitButtonCloseCommand = new RelayCommand<ProductCreationPageUC>((productCreationUC) => { return true; }, (productCreationUC) => {
                productCreationUC.btnClose.Visibility = Visibility.Collapsed;
                productCreationUC.imgContainer.Children.Clear();
                ImagePathList.Clear();
            });

            OpenDialogMeidaCommand = new RelayCommand<ProductCreationPageUC>((productCreationUC) => { return true; }, (productCreationUC) => {
                OpenFileDialog openfileDialog = new OpenFileDialog();
                openfileDialog.Filter = "Image files (*.jpg)|*.jpg";
                openfileDialog.FilterIndex = 1;
                openfileDialog.Multiselect = true;
                openfileDialog.Title = "Chọn Avatar";

                if (openfileDialog.ShowDialog() == true)
                {
                    if(productCreationUC.btnClose.Visibility == Visibility.Collapsed)
                    {
                        productCreationUC.btnClose.Visibility = Visibility.Visible;
                    }

                    string fileExtension = Path.GetExtension(openfileDialog.FileName);

                    if (fileExtension == ".jpg")
                    {
                        ImageItemUC imageItem = new ImageItemUC();
                        imageItem.Image = new BitmapImage(new Uri(openfileDialog.FileName));
                        imageItem.Margin = new Thickness(5,0,5,0); 

                        productCreationUC.imgContainer.Children.Add(imageItem);
                        ImagePathList.Add(openfileDialog.FileName);
                    }
                }
            });

            SubmitButtonCreationProductCommand = new RelayCommand<ProductCreationPageUC>((productCreationUC) => { return true; }, async (productCreationUC) => {
                
                try
                {
                    PRODUCT_CATEGORY categorySeleted = productCreationUC.cbxCategoryType.SelectedItem as PRODUCT_CATEGORY;

                    Product product = null;
                    if (categorySeleted.CATEGORY_CODE == "game")
                    {
                        product = new Product_Game();
                        product.Type = "Game";
                    }
                    else if (categorySeleted.CATEGORY_CODE == "computer")
                    {
                        product = new Product_Computer();
                        product.Type = "Computer";
                    }
                    else if (categorySeleted.CATEGORY_CODE == "movie")
                    {
                        product = new Product_Movie();
                        product.Type = "Movie";

                    }

                    product.Name = productCreationUC.txtName.Text;
                    product.Detail = productCreationUC.txtDetail.Text;
                    product.Decriptions = productCreationUC.txtDecription.Text;

                    int result;
                    if (Int32.TryParse(productCreationUC.txtPrice.Text, out result))
                    {
                        product.Price = result;
                    }
                    else
                    {
                        MessageBox.Show("Giá bán phải là số", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                        product = null;
                        return;
                    }

                    string pathBefore = "";
                    foreach (string imgPath in ImagePathList)
                    {
                        if(imgPath == pathBefore)
                        {
                            MessageBox.Show("Ảnh không được trùng", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                            product = null;
                            return;
                        }

                        pathBefore = imgPath;
                        string fileName = Path.GetFileName(imgPath);
                        product.ImageList.Add(fileName);
                    }

                    bool isProductValid = await ValidationProductHandling.ProductValidation(product);
                    if (!isProductValid)
                    {
                        product = null;
                        return;
                    }

                    
                    string fullPathDirectory = Path.GetFullPath("..//..//Images//Product//");
                    string folderPathProduct = fullPathDirectory + product.Name;

                    if (Directory.Exists(folderPathProduct))
                    {
                        MessageBox.Show("Trùng tên sản phẩm", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                        product = null;
                        return;
                    }
                    else
                    {
                        Directory.CreateDirectory(folderPathProduct);
                    }

                    foreach (string imgPath in ImagePathList)
                    {
                        string resourceImg = folderPathProduct + "\\" + Path.GetFileName(imgPath);

                        if (File.Exists(resourceImg))
                        {
                            continue;
                        }

                        File.Copy(imgPath, resourceImg, true);   
                    }

                    bool isInsertSucess = false;
                    if (product.Type == "Game")
                    {
                        Product_GameDBHandler db = new Product_GameDBHandler();
                        isInsertSucess = await db.InsertOneProductAsync(product as Product_Game);
                    }
                    else if (product.Type == "Computer")
                    {
                        Product_ComputerDBHandler db = new Product_ComputerDBHandler();
                        isInsertSucess = await db.InsertOneProductAsync(product as Product_Computer);
                    }
                    else if (product.Type == "Movie")
                    {
                        Product_MovieDBHandler db = new Product_MovieDBHandler();
                        isInsertSucess = await db.InsertOneProductAsync(product as Product_Movie);
                    }

                    
                    ProductVM productVM = new ProductVM();
                    productVM.productID = product.Id.ToString();
                    productVM.Type.Name = categorySeleted.CATEGORY_NAME;
                    productVM.Type.typeId = categorySeleted.CATEGORY_CODE;
                    productVM.Name = product.Name;
                    productVM.Avatar = product.ImageList[0];
                    productVM.Producer.producerID = ProducerUser.Id.ToString();
                    productVM.Producer.Name = ProducerUser.Name;
                    productVM.Producer.avatar = ProducerUser.Avatar;
                    productVM.CreatedAt = DateTime.Now;

                    ProductVMDBHandler productVMDBHandler = new ProductVMDBHandler();
                    isInsertSucess = await productVMDBHandler.InsertOneProductVMAsync(productVM);


                    if (!isInsertSucess)
                    {
                        MessageBox.Show("Tạo sản phẩm thất bại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }


                    MessageBox.Show("Tạo sản phẩm thành công", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo sản phẩm thất bại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

            });

        }


    }
}
