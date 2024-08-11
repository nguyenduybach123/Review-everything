using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review_Project.Core;
using Review_Project.MVVM.View.UserControlView;

namespace Review_Project.MVVM.ViewModel
{
    public class ActivityMeterViewModel : BaseViewModel
    {
        public ICommand LoadedActivityMeterCommand { get; set; }
        public ActivityMeterViewModel()
        {
            LoadedActivityMeterCommand = new RelayCommand<ActivityMeterUC>((activityMeterUC) => { return true; }, (activityMeterUC) => {
                int width = (((activityMeterUC.Value * 100) / activityMeterUC.Summary) * activityMeterUC.WidthProgress) / 100;
                activityMeterUC.activityProgress.Width = width;
                activityMeterUC.activityValue.Text = activityMeterUC.Value.ToString();
            });
        }
    }
}
