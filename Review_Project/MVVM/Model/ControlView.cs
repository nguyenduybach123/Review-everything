using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Review_Project.MVVM.ViewModel;

namespace Review_Project.MVVM.Model
{
    public class ControlView
    {
        private ArrayList listViewPage;

        public ControlView() {
            listViewPage = new ArrayList();
        }

        public void Push<T>(T page) {
            listViewPage.Add(page);
        }

        private void Pop()
        {
            listViewPage.RemoveAt(listViewPage.Count - 1);
        }

        public void Clear()
        {
            listViewPage.Clear();
        }

        public void getPreviousViewPage(ref object currentView) {

            if (listViewPage.Count <= 2) {

                if (listViewPage.Count == 2) { 
                    Pop();
                }

                if (listViewPage[0] is ProfileInfoViewModel)
                {
                    currentView = listViewPage[0] as ProfileInfoViewModel;
                }
                else if (listViewPage[0] is ProductHomePageViewModel)
                {
                    currentView = listViewPage[0] as ProductHomePageViewModel;
                }
                else if (listViewPage[0] is ProductPostCreationPageViewModel)
                {
                    currentView = listViewPage[0] as ProductPostCreationPageViewModel;
                }
                else if (listViewPage[0] is ProductCreationPageViewModel)
                {
                    currentView = listViewPage[0] as ProductCreationPageViewModel;
                }
                else if (listViewPage[0] is ProducerProductPageViewModel)
                {
                    currentView = listViewPage[0] as ProducerProductPageViewModel;
                }
                else if (listViewPage[0] is ProducerProfileInfoViewModel)
                {
                    currentView = listViewPage[0] as ProducerProfileInfoViewModel;
                }
                else if (listViewPage[0] is ProductAnalyticsViewModel)
                {
                    currentView = listViewPage[0] as ProductAnalyticsViewModel;
                }

                return;
            }

            Pop();

            int lastIdx = listViewPage.Count - 1;
            
            if (listViewPage[lastIdx] is ProductInfoDetailViewModel) {
                currentView = listViewPage[lastIdx] as ProductInfoDetailViewModel;
            }
            else if (listViewPage[lastIdx] is ProductAnalyticsViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductAnalyticsViewModel;
            }

        }

        public void getLastViewPage(ref object currentView)
        {

            int lastIdx = listViewPage.Count - 1;

            if (listViewPage[lastIdx] is ProfileInfoViewModel)
            {
                currentView = listViewPage[lastIdx] as ProfileInfoViewModel;
            }
            else if (listViewPage[lastIdx] is ProductHomePageViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductHomePageViewModel;
            }
            else if (listViewPage[lastIdx] is ProductInfoDetailViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductInfoDetailViewModel;
            }
            else if(listViewPage[lastIdx] is ProductPostCreationPageViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductPostCreationPageViewModel;
            }
            else if (listViewPage[lastIdx] is ProductCreationPageViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductCreationPageViewModel;
            }
            else if (listViewPage[lastIdx] is ProducerProductPageViewModel)
            {
                currentView = listViewPage[lastIdx] as ProducerProductPageViewModel;
            }
            else if (listViewPage[lastIdx] is ProductPostViewPageViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductPostViewPageViewModel;
            }
            else if (listViewPage[lastIdx] is ProducerProfileInfoViewModel)
            {
                currentView = listViewPage[lastIdx] as ProducerProfileInfoViewModel;
            }
            else if (listViewPage[lastIdx] is ProductAnalyticsViewModel)
            {
                currentView = listViewPage[lastIdx] as ProductAnalyticsViewModel;
            }
        }

    }
}
