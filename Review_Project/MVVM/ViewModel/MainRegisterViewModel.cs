using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;

namespace Review_Project.MVVM.ViewModel
{
    public class MainRegisterViewModel : ObservableObject
    {
        public ReviewerRegisterViewModel ReviewerRegisterVM { get; set; }

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
        public MainRegisterViewModel()
        {
            ReviewerRegisterVM = new ReviewerRegisterViewModel();
            CurrentView = ReviewerRegisterVM;
        }
    }
}
