using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.MVVM.Model;
using Review_Project.MVVM.Model.MongoDB_Connect;
using Review_Project.MVVM.View.UserControlView;
using System.Windows.Controls;
using System.Windows.Input;
using Review_Project.Core;
using System.Windows;
using System.Windows.Media.Animation;

namespace Review_Project.MVVM.ViewModel
{
    public class CarouselSlideViewModel : BaseViewModel
    {
        readonly Duration _animationDuration = new Duration(TimeSpan.FromSeconds(0.3));

        private List<SlidePage> slides = new List<SlidePage>();

        private int currentSlide;

        public ICommand LoadCarouselSlideCommand { get; set; }
        public ICommand DragRightSlideCommand { get; set; }
        public ICommand DragLeftSlideCommand  { get; set; }

        public CarouselSlideViewModel() {
            LoadCarouselSlideCommand = new RelayCommand<CarouselUC>((carouselUC) => { return true; }, (carouselUC) =>{
                initCarouseSlides((int)carouselUC.SlideNumber,carouselUC.SlideContainer);
            });
        }

        public async void initCarouseSlides(int slideNumber, Panel slideContainer) {
            //try {

            //    ProductDBHandler db = new ProductDBHandler();
            //    List<Product> newProducts = (List<Product>)await db.GetNewProductAsync(slideNumber);

            //    foreach(Product product in newProducts) {
            //        SlidePage slide = new SlidePage();
            //        Control control = new Control();
            //        slide.SlideControl = control;
            //        slide.ProductID = product.Id;
            //        slide.ImageURL = product.Avatar;

            //        slides.Add(slide);
            //        slideContainer.Children.Add(control);
            //    }
            //}
            //catch {
            //    Console.WriteLine("Error !!!");
            //}
        }

        DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventHandler)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, _animationDuration);
            if (completedEventHandler != null)
            {
                doubleAnimation.Completed += completedEventHandler;
            }
            return doubleAnimation;
        }

        void SlideAnimation(UIElement newContent, UIElement oldContent, Panel TransitionContainer, EventHandler completeEventHandler)
        {
            double leftStart = Canvas.GetLeft(oldContent);
            Canvas.SetLeft(newContent, leftStart - TransitionContainer.Width);
            TransitionContainer.Children.Add(newContent);
            if (double.IsNaN(leftStart))
            {
                leftStart = 0;
            }
            DoubleAnimation outAnimation = CreateDoubleAnimation(leftStart, leftStart + TransitionContainer.Width, null);
            DoubleAnimation inAnimation = CreateDoubleAnimation(leftStart - TransitionContainer.Width, leftStart, completeEventHandler);
            oldContent.BeginAnimation(Canvas.LeftProperty, outAnimation);
            newContent.BeginAnimation(Canvas.LeftProperty, inAnimation);
        }
    }


}
