using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Review_Project.MVVM.Model.MongoDB_Connect;

namespace Review_Project.MVVM.Model
{
    public class ValidationPostHandling
    {
        public static async Task<bool> PostValidation(Post post)
        {
            if(post.Title == "" || post.Type == "" || post.ProductID == "")
            {
                MessageBox.Show("Yêu cầu điền đầy đủ thông tin", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            try
            {
                bool isProductExits = true;
                if(post.Type == "game")
                {
                    Product_GameDBHandler db = new Product_GameDBHandler();
                    Product_Game productGame = await db.GetProductToIDAsync(post.ProductID);

                    if(productGame == null)
                    {
                        isProductExits = false;
                    }

                }
                else if(post.Type == "computer")
                {
                    Product_ComputerDBHandler db = new Product_ComputerDBHandler();
                    Product_Computer productComputer = await db.GetProductToIDAsync(post.ProductID);

                    if (productComputer == null)
                    {
                        isProductExits = false;
                    }
                }
                else if(post.Type == "movie") 
                {
                    Product_MovieDBHandler db = new Product_MovieDBHandler();
                    Product_Movie productMovie = await db.GetProductToIDAsync(post.ProductID);

                    if (productMovie == null)
                    {
                        isProductExits = false;
                    }
                }
                else
                {
                    isProductExits = false;
                }

                if (!isProductExits)
                {
                    MessageBox.Show("Sản phẩm không tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Sản phẩm không tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if(post.XML == null || post.XML.Length == 0)
            {
                MessageBox.Show("Post không tồn tại", "Yêu cầu", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }
    }
}
