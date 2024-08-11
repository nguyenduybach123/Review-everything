using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Controls;
using System.Windows;
using MongoDB.Bson;
using LiveCharts.Defaults;

namespace Review_Project.MVVM.ViewModel
{
    public class ProductAnalyticsViewModel :BaseViewModel
    {
        public ProducerMainPageViewModel MainPage { get; set; }
        public Product Product { get; set; }
        public SeriesCollection SeriesCollection_ChartColumn { get; set; }
        public string[] Labels_ChartColumn { get; set; }
        public Func<double, string> Formatter_ChartColumn { get; set; }

        public SeriesCollection SeriesCollection_ChartPie { get; set; }
        public string[] Labels_ChartPie { get; set; }
        public Func<double, string> Formatter_ChartPie { get; set; }

        public ICommand BackPreviousViewPageCommand { get; set; }
        public ICommand LoadProductAnalyticsPageCommand { get; set; }
        public ICommand LoadChartColumnAnalyticsCommand { get; set; }
        public ICommand LoadChartPieAnalyticsCommand { get; set; }

        public ProductAnalyticsViewModel()
        {

           
            BackPreviousViewPageCommand = new RelayCommand<UserControl>((uc) => { return true; }, (uc) =>
            {
                Window mainWindow = Window.GetWindow(uc);
                MainWindowViewModel mainWindowVM = mainWindow.DataContext as MainWindowViewModel;

                if (mainWindowVM.CurrentView is ProducerMainPageViewModel producerMainUC)
                {
                    object previousViewPage = null;
                    MainPage.controlViewPage_MyProductPage.getPreviousViewPage(ref previousViewPage);
                    MainPage.CurrentView = previousViewPage;
                }

            });

            LoadProductAnalyticsPageCommand = new RelayCommand<ProductAnalyticsUC>((productAnalyticsUC) => { return true; }, async (productAnalyticsUC) =>
            {

                if (Product == null)
                    return;

                productAnalyticsUC.cardView.Value = KMB_Format(Product.View);
                productAnalyticsUC.cardLike.Value = KMB_Format(Product.Like);
                productAnalyticsUC.cardFeedback.Value = KMB_Format(Product.NumberReview);
                productAnalyticsUC.cardMoney.Value = KMB_Format((Product.NumberSold * Product.Price));
            });


            LoadChartColumnAnalyticsCommand = new RelayCommand<ProductAnalyticsUC>((productAnalyticsUC) => { return true; }, async (productAnalyticsUC) =>
            {
                if(Product.Type == "Game")
                {
                    CommentDBHandler db = new CommentDBHandler("Game");
                    List<BsonDocument> result = await db.GetNumberOfCommentByMonthAsync(Product.Id.ToString());

                    int[] countCommentInMonth = parseBsonResult(result);

                    SeriesCollection_ChartColumn = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Comment",
                            Values = new ChartValues<int>(countCommentInMonth)
                        }
                    };
                }
                else if(Product.Type == "Computer")
                {
                    CommentDBHandler db = new CommentDBHandler("Computer");
                    List<BsonDocument> result = await db.GetNumberOfCommentByMonthAsync(Product.Id.ToString());

                    int[] countCommentInMonth = parseBsonResult(result);

                    SeriesCollection_ChartColumn = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Comment",
                            Values = new ChartValues<int>(countCommentInMonth)
                        }
                    };
                }
                else if(Product.Type == "Movie")
                {
                    CommentDBHandler db = new CommentDBHandler("Movie");
                    List<BsonDocument> result = await db.GetNumberOfCommentByMonthAsync(Product.Id.ToString());

                    int[] countCommentInMonth = parseBsonResult(result);

                    SeriesCollection_ChartColumn = new SeriesCollection
                    {
                        new ColumnSeries
                        {
                            Title = "Comment",
                            Values = new ChartValues<int>(countCommentInMonth)
                        }
                    };
                }

                Labels_ChartColumn = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };

                productAnalyticsUC.ColumnChart.Series = SeriesCollection_ChartColumn;

            });


            LoadChartPieAnalyticsCommand = new RelayCommand<ProductAnalyticsUC>((productAnalyticsUC) => { return true; }, (productAnalyticsUC) =>
            {
                if(Product.Type == "Game")
                {

                    Product_Game productGame = Product as Product_Game;

                    SeriesCollection_ChartPie = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Cốt Truyện",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productGame.StoryRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Gameplay",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productGame.GamePlayRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Đồ Họa",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productGame.GraphicRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Âm Nhạc",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productGame.SoundRating) },
                            DataLabels = true
                        }
                    };
                }
                else if(Product.Type == "Computer")
                {

                    Product_Computer productComputer = Product as Product_Computer;

                    SeriesCollection_ChartPie = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Mượt Mà",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productComputer.SmoothRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Chất Liệu",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productComputer.MaterialRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Như Mô Tả",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productComputer.SameAsDescriptionRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Bảo Hành",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productComputer.TakeCareRating) },
                            DataLabels = true
                        }
                    };
                }
                else if(Product.Type == "Movie")
                {
                    Product_Movie productMovie = Product as Product_Movie;

                    SeriesCollection_ChartPie = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Cốt Truyện",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productMovie.StoryRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Đồ Họa",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productMovie.GraphicRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Âm Nhạc",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productMovie.SoundRating) },
                            DataLabels = true
                        },
                        new PieSeries
                        {
                            Title = "Như Mô Tả",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(productMovie.SameAsDescriptionRating) },
                            DataLabels = true
                        }
                    };
                }

                productAnalyticsUC.PieChart.Series = SeriesCollection_ChartPie;

            });

        }

        public string KMB_Format(int value)
        {
            if((value / 1000) < 1)
            {
                return value.ToString();
            }

            if((value / 1000) < 1000)
            {
                if (value % 1000 == 0)
                {
                    return (value / 1000) + "K";
                }
                else
                {
                    float realNumber = ((float)value / 1000) - (value / 1000);

                    if (realNumber < 0.1)
                    {
                        return (value / 1000) + "K";
                    }
                    else
                    {
                        return ((float)value / 1000) + "K";
                    }

                }
            }

            if((value / 1000) < 1000000)
            {
                if (value % 1000000 == 0)
                {
                    return (value / 1000000) + "M";
                }
                else
                {
                    float realNumber = ((float)value / 1000000) - (value / 1000000);

                    if (realNumber < 0.1)
                    {
                        return (value / 1000000) + "M";
                    }
                    else
                    {
                        return ((float)value / 1000000) + "M";
                    }

                }
            }

            return value.ToString();
           
        }

        public int[] parseBsonResult(List<BsonDocument> result)
        {
            int[] arrayCommentOfMonth = new int[12];
            foreach (BsonDocument document in result)
            {

                var month = document["_id"].AsInt32;
                var count = document["tong"].AsInt32;

                arrayCommentOfMonth[month - 1] = count;
             
            }

            return arrayCommentOfMonth;
        }

    }
}
