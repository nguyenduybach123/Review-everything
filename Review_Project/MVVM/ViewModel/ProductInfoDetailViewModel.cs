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
using MongoDB.Driver;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductInfoDetailViewModel : ObservableObject
    {
        private ProductDBHandler.TYPE _type;
        public string ProductID { get; set; }

        public Product CurrentProduct { get; set; }

        public ProductCommentPageViewModel CommentPageVM;
        public ProductPostListViewModel PostListPageVM;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RatingSummaryProductGameViewModel RatingGameVM;
        public RatingSummaryProductComputerViewModel RatingComputerVM;
        public RatingSummaryProductMovieViewModel RatingMovieVM;

        private object _currentRating;
        public object CurrentRating
        {
            get { return _currentRating; }
            set
            {
                _currentRating = value;
                OnPropertyChanged();
            }
        }

        public ICommand BackPreviousViewPageCommand { get; set; }
        public ICommand LoadProductInfoDetailCommand { get; set; }
        public ICommand LoadRatingSummaryCommand { get; set; }
        public ICommand SubmitGetProductCodeCommand { get; set; }
        public ICommand SelectedCommentViewCommand  { get; set; }
        public ICommand SelectedPostViewCommand { get; set; }
        public ICommand SubmitBuyNowCommand { get; set; }

        public ProductInfoDetailViewModel()
        {

            CommentPageVM = new ProductCommentPageViewModel();
            PostListPageVM = new ProductPostListViewModel();
            CurrentView = CommentPageVM;

            BackPreviousViewPageCommand = new RelayCommand<UserControl>((uc) => { return true; }, (uc) =>
            {

                Window mainWindow = Window.GetWindow(uc);
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                if (mainWindowVM.CurrentView is ReviewerMainPageViewModel reviewerMainUC)
                {
                    object previousViewPage = null;
                    reviewerMainUC.controlViewPage_ProductPage.getPreviousViewPage(ref previousViewPage);
                    reviewerMainUC.CurrentView = previousViewPage;
                }


            });

            LoadProductInfoDetailCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailPageUC) => { return true; }, async (infoDetailPageUC) =>
            {
                try
                {
                    switch (_type)
                    {
                        case ProductDBHandler.TYPE.Game:
                            Product_GameDBHandler productGameDB = new Product_GameDBHandler();
                            Product productGame = await productGameDB.GetProductToIDAsync(ProductID);
                            CurrentProduct = productGame;

                            if (productGame == null) return;

                            infoDetailPageUC.productName.Text = productGame.Name;
                            //infoDetailPageUC.productRank.Text = productGame.Rank.ToString();
                            infoDetailPageUC.productReview.Text = productGame.NumberReview.ToString();
                            infoDetailPageUC.productSold.Text = productGame.NumberSold.ToString();
                            int ratingStar = (productGame.NumberReview + productGame.NumberSold) / 2;
                            infoDetailPageUC.productRating.Value = ratingStar;
                            infoDetailPageUC.btnXML.ToolTipContent = productGame.Id.ToString();
                            infoDetailPageUC.productDetail.Text = productGame.Detail;
                            infoDetailPageUC.productDecription.Text = productGame.Decriptions;

                            foreach (string imgName in productGame.ImageList)
                            {
                                string imgUrl = createPathToProductImg(productGame.Name, imgName);
                                infoDetailPageUC.productImageView.ImageList.Add(imgUrl);
                            }


                            break;

                        case ProductDBHandler.TYPE.Computer:
                            Product_ComputerDBHandler productComputerDB = new Product_ComputerDBHandler();
                            Product productComputer = await productComputerDB.GetProductToIDAsync(ProductID);
                            CurrentProduct = productComputer;


                            if (productComputer == null) return;

                            infoDetailPageUC.productName.Text = productComputer.Name;
                            //infoDetailPageUC.productRank.Text = productComputer.Rank.ToString();
                            infoDetailPageUC.productReview.Text = productComputer.NumberReview.ToString();
                            infoDetailPageUC.productSold.Text = productComputer.NumberSold.ToString();
                            int ratingStar1 = (productComputer.NumberReview + productComputer.NumberSold) / 2;
                            infoDetailPageUC.productRating.Value = ratingStar1;
                            infoDetailPageUC.btnXML.ToolTipContent = productComputer.Id.ToString();
                            infoDetailPageUC.productDetail.Text = productComputer.Detail;
                            infoDetailPageUC.productDecription.Text = productComputer.Decriptions;

                            foreach (string imgName in productComputer.ImageList)
                            {
                                string imgUrl = createPathToProductImg(productComputer.Name, imgName);
                                infoDetailPageUC.productImageView.ImageList.Add(imgUrl);
                            }


                            break;

                        case ProductDBHandler.TYPE.Movie:
                            Product_MovieDBHandler productMovieDB = new Product_MovieDBHandler();
                            Product productMovie = await productMovieDB.GetProductToIDAsync(ProductID);
                            CurrentProduct = productMovie;

                            if (productMovie == null) return;

                            infoDetailPageUC.productName.Text = productMovie.Name;
                            //infoDetailPageUC.productRank.Text = productMovie.Rank.ToString();
                            infoDetailPageUC.productReview.Text = productMovie.NumberReview.ToString();
                            infoDetailPageUC.productSold.Text = productMovie.NumberSold.ToString();
                            int ratingStar2 = (productMovie.NumberReview + productMovie.NumberSold) / 2;
                            infoDetailPageUC.productRating.Value = ratingStar2;
                            infoDetailPageUC.btnXML.ToolTipContent = productMovie.Id.ToString();
                            infoDetailPageUC.productDetail.Text = productMovie.Detail;
                            infoDetailPageUC.productDecription.Text = productMovie.Decriptions;

                            foreach (string imgName in productMovie.ImageList)
                            {
                                string imgUrl = createPathToProductImg(productMovie.Name, imgName);
                                infoDetailPageUC.productImageView.ImageList.Add(imgUrl);
                            }


                            break;

                        default:
                            break;
                    }

                    PostListPageVM.ProductID = ProductID;
                    PostListPageVM.ProductType = _type.ToString();

                    CommentPageVM.ProductID = ProductID;
                    CommentPageVM.CommentType = _type.ToString();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            LoadRatingSummaryCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailPageUC) => { return true; }, async (infoDetailPageUC) => {

                switch (_type)
                {
                    case ProductDBHandler.TYPE.Game:
                        Product_Game productGame = CurrentProduct as Product_Game;
                        RatingGameVM = new RatingSummaryProductGameViewModel();
                        RatingGameVM.Product = productGame;
                        CurrentRating = RatingGameVM;
                        return;


                    case ProductDBHandler.TYPE.Computer:
                        Product_Computer productComputer = CurrentProduct as Product_Computer;
                        RatingComputerVM = new RatingSummaryProductComputerViewModel();
                        RatingComputerVM.Product = productComputer;
                        CurrentRating = RatingComputerVM;
                        return;

                    case ProductDBHandler.TYPE.Movie:
                        Product_Movie productMovie = CurrentProduct as Product_Movie;
                        RatingMovieVM = new RatingSummaryProductMovieViewModel();
                        RatingMovieVM.Product = productMovie;
                        CurrentRating = RatingMovieVM;
                        return;
                }
            });

            SubmitGetProductCodeCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailUC) => { return true; }, (infoDetailUC) => {
                MessageBox.Show("Lấy mã thành công","Xác Nhận", MessageBoxButton.OK, MessageBoxImage.Information);
                Clipboard.SetText(infoDetailUC.btnXML.ToolTipContent);
            });


            SelectedCommentViewCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailUC) => { return true; }, (infoDetailUC) => {
                CurrentView = CommentPageVM;
            });

            SelectedPostViewCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailUC) => { return true; }, (infoDetailUC) => {
                CurrentView = PostListPageVM;
            });

            SubmitBuyNowCommand = new RelayCommand<ProductInfoDetailUC>((infoDetailUC) => { return true; }, async (infoDetailUC) => {
                try
                {
                    MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
                    MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                    ReviewerDBHandler db = new ReviewerDBHandler();
                    UpdateResult result = await db.UpdateOneReviewerSoldAsync(mainWindowVM.ReviewerUser.Id,ProductID);
                    if (result.MatchedCount > 0)
                    {
                        bool isSucess = false;
                        if(_type == ProductDBHandler.TYPE.Game)
                        {
                            Product_GameDBHandler dbGame = new Product_GameDBHandler();
                            UpdateResult res = await dbGame.UpdateOneProductSoldAsync(ProductID, CurrentProduct.NumberSold + 1);
                            if(res.MatchedCount > 0)
                            {
                                CurrentProduct.NumberSold++;
                                isSucess = true;
                            }
                        }
                        else if(_type == ProductDBHandler.TYPE.Computer)
                        {
                            Product_ComputerDBHandler dbComputer = new Product_ComputerDBHandler();
                            UpdateResult res = await dbComputer.UpdateOneProductSoldAsync(ProductID, CurrentProduct.NumberSold + 1);
                            if (res.MatchedCount > 0)
                            {
                                CurrentProduct.NumberSold++;
                                isSucess = true;
                            }
                        }
                        else if(_type == ProductDBHandler.TYPE.Movie)
                        {
                            Product_MovieDBHandler dbMovie = new Product_MovieDBHandler();
                            UpdateResult res = await dbMovie.UpdateOneProductSoldAsync(ProductID, CurrentProduct.NumberSold + 1);
                            if (res.MatchedCount > 0)
                            {
                                CurrentProduct.NumberSold++;
                                isSucess = true;
                            }
                        }
                        else
                        {
                            return;
                        }

                        if (!isSucess)
                        {
                            MessageBox.Show("Mua thất bại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Question);
                            this.LoadProductInfoDetailCommand.Execute(infoDetailUC);
                            return;
                        }

                        MessageBox.Show("Mua thành công","Xác nhận",MessageBoxButton.OK,MessageBoxImage.Question);
                        CommentPageVM.UserCommentInput.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Mua thất bại", "Xác nhận", MessageBoxButton.OK, MessageBoxImage.Question);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            });

        }

        public void SetProductType(string type)
        {
            if(type == "game")
            {
                _type =  ProductDBHandler.TYPE.Game;
            }
            else if (type == "computer")
            {
                _type = ProductDBHandler.TYPE.Computer;
            }
            else if (type == "movie")
            {
                _type = ProductDBHandler.TYPE.Movie;
            }
        }

        private string createPathToProductImg(string folderName, string imgName)
        {
            string fullDirectory = Path.GetFullPath("..//..//Images//Product//");
            string strImg = fullDirectory + folderName + "\\" + imgName;
            return strImg;
        }


    }
}
