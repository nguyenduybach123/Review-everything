using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.Core;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace Review_Project.MVVM.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseDragWindowCommand { get; set; }

        public ControlBarViewModel()
        {

            CloseWindowCommand = new RelayCommand<UserControl>((uc) => { return uc == null ? false : true; }, (uc) => {
                Window mainWindow = Window.GetWindow(uc);

                if (mainWindow != null)
                {
                    mainWindow.Close();
                }

            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((uc) => { return uc == null ? false : true; }, (uc) => {
                Window mainWindow = Window.GetWindow(uc);

                if (mainWindow != null)
                {
                    if (mainWindow.WindowState != WindowState.Minimized)
                        mainWindow.WindowState = WindowState.Minimized;
                    else
                        mainWindow.WindowState = WindowState.Maximized;
                }

            });

            MouseDragWindowCommand = new RelayCommand<UserControl>((uc) => { return uc == null ? false : true; }, (uc) => {
                Window mainWindow = Window.GetWindow(uc);

                if (mainWindow != null)
                {
                    mainWindow.DragMove();
                }

            });
        }

    }
}
