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
    public class RatingSummaryProductMovieViewModel : BaseViewModel
    {
        public Product_Movie Product { get; set; }

        public ICommand LoadRatingSummaryCommand { get; set; }
        public RatingSummaryProductMovieViewModel()
        {
            LoadRatingSummaryCommand = new RelayCommand<RatingSummaryProductMovieUC>((ratingSummaryUC) => { return true; }, (ratingSummaryUC) => {
                ratingSummaryUC.meterAsDecription.Value = Product.SameAsDescriptionRating;
                ratingSummaryUC.meterGraphic.Value = Product.GraphicRating;
                ratingSummaryUC.meterSound.Value = Product.SoundRating;
                ratingSummaryUC.meterStory.Value = Product.StoryRating;

                int rating = (Product.SameAsDescriptionRating + Product.GraphicRating + Product.SoundRating + Product.StoryRating) / 4;
                ratingSummaryUC.ProgressCircle.Value = rating;

            });
        }

    }
}
