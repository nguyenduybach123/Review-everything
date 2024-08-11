using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;

namespace Review_Project.MVVM.ViewModel
{
    public class MainLoginViewModel : ObservableObject
    {

        public enum UserType {
            Reviewer,
            Producer
        }


        public bool IsSuccessLogin { get; set; }

        public string UserID { get; set; }

        public UserType LoginType { get; set; }

        public ReviewerLoginViewModel ReviewerLoginVM { get; set; }

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

        public MainLoginViewModel() {

            IsSuccessLogin = false;
            ReviewerLoginVM = new ReviewerLoginViewModel();
            CurrentView = ReviewerLoginVM;

        }

    }
}
