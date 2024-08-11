using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductImageListViewModel : ObservableObject
    {
        public Image imageMain { get; set; }
        public ICommand LoadProductImageListCommand { get; set; }
        public ICommand LoadMainImageCommand { get; set; }
        public ProductImageListViewModel()
        {
            LoadProductImageListCommand = new RelayCommand<ProductImageListUC>((productImageListUC) => { return true; }, async (productImageListUC) =>
            {
                string mainPath = productImageListUC.ImageList.FirstOrDefault();
                productImageListUC.imgMain.Source = new BitmapImage(new Uri(mainPath));

                int currentPos = 0;
                foreach (string imgURL in productImageListUC.ImageList)
                {
                    ImageItemUC productImg = new ImageItemUC();
                    productImg.Image = new BitmapImage(new Uri(imgURL));
                    productImg.Margin = new System.Windows.Thickness(5);
                    productImg.MouseLeftButtonDown += ImageItem_MouseLeftButtonDown;
                    productImageListUC.imgContainer.Children.Add(productImg);
                    currentPos += 110;
                }

                imageMain = productImageListUC.imgMain;

            });

        }


        public void ImageItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (imageMain == null)
                return;

            ImageItemUC image = sender as ImageItemUC;
            imageMain.Source = new BitmapImage(new Uri(image.Image.ToString()));
        }
    }
}
