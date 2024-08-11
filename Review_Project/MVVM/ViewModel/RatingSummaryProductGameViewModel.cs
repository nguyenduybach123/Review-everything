using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class RatingSummaryProductGameViewModel : BaseViewModel
    {
        public Product_Game Product { get; set; }

        public ICommand LoadRatingSummaryCommand { get; set; }
        public RatingSummaryProductGameViewModel()
        {
            LoadRatingSummaryCommand = new RelayCommand<RatingSummaryProductGameUC>((ratingSummaryUC) => { return true; }, (ratingSummaryUC) => {
                ratingSummaryUC.meterGamePlay.Value = Product.GamePlayRating;
                ratingSummaryUC.meterGraphic.Value = Product.GraphicRating;
                ratingSummaryUC.meterSound.Value = Product.SoundRating;
                ratingSummaryUC.meterStory.Value = Product.StoryRating;

                int rating = (Product.GamePlayRating + Product.GraphicRating + Product.SoundRating + Product.StoryRating) / 4;
                ratingSummaryUC.ProgressCircle.Value = rating;

            });
        }
    }
}
