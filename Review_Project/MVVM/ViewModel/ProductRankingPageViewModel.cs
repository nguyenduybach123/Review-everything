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
    public class ProductRankingPageViewModel : ObservableObject
    {
        public ICommand LoadedRankingPageCommand { get; set; }
        public ProductRankingPageViewModel() {

            LoadedRankingPageCommand = new RelayCommand<ProductRankingPage>((rankingPageUC) => { return true; }, async (rankingPageUC) => {

            });
        }
    }
}
