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
    public class RatingSummaryProductComputerViewModel : BaseViewModel
    {
        public Product_Computer Product { get; set; }

        public ICommand LoadRatingSummaryCommand { get; set; }
        public RatingSummaryProductComputerViewModel()
        {
            LoadRatingSummaryCommand = new RelayCommand<RatingSummaryProductComputerUC>((ratingSummaryUC) => { return true; }, (ratingSummaryUC) => {
                ratingSummaryUC.meterAsDecription.Value = Product.SameAsDescriptionRating;
                ratingSummaryUC.meterMaterail.Value = Product.MaterialRating;
                ratingSummaryUC.meterSmooth.Value = Product.SmoothRating;
                ratingSummaryUC.meterMaintennance.Value = Product.TakeCareRating;

                int rating = (Product.SameAsDescriptionRating + Product.MaterialRating + Product.SmoothRating + Product.TakeCareRating) / 4;
                ratingSummaryUC.ProgressCircle.Value = rating;
            });
        }
    }
}
