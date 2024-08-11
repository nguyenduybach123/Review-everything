using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Review_Project.MVVM.Model.MongoDB_Connect;

namespace Review_Project.MVVM.Model
{
    public class ValidationProductHandling
    {
        public static async Task<bool> ProductValidation(Product product)
        {
            try
            {
                if (product.Name == "" || product.Detail == "" || product.Decriptions == "")
                {
                    MessageBox.Show("Yêu cầu điền đầy đủ thông tin", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

                if (product.Price <= 1000)
                {
                    MessageBox.Show("Yêu cầu giá bán lớn hơn 1.000", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

                if (product.ImageList.Count < 5)
                {
                    MessageBox.Show("Yêu cầu tập hình ảnh > 4", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }


                bool isSameName = false;
                if(product.Type == "Game")
                {
                    Product_GameDBHandler db = new Product_GameDBHandler();
                    Product_Game product_Game = await db.GetProductByNameAsync(product.Name);
                    if(product_Game != null)
                    {
                        isSameName = true;
                    }
                }
                else if (product.Type == "Computer")
                {
                    Product_ComputerDBHandler db = new Product_ComputerDBHandler();
                    Product_Computer product_Computer = await db.GetProductByNameAsync(product.Name);
                    if (product_Computer != null)
                    {
                        isSameName = true;
                    }
                }
                else if (product.Type == "Movie")
                {
                    Product_MovieDBHandler db = new Product_MovieDBHandler();
                    Product_Movie product_Movie = await db.GetProductByNameAsync(product.Name);
                    if (product_Movie != null)
                    {
                        isSameName = true;
                    }
                }

                if(isSameName)
                {
                    MessageBox.Show("Sản phẩm đã tồn tại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
