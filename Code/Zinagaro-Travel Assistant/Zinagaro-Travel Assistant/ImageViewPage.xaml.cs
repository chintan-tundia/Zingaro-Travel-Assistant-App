using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Zinagaro_Travel_Assistant
{
    public partial class ImageViewPage : PhoneApplicationPage
    {
        public ImageViewPage()
        {
            InitializeComponent();
        }
        string path;
        int ind;
        bool flag = false;
        int startpoint;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                string val = NavigationContext.QueryString["id"];
                ind = Convert.ToInt32(val);
                Photo p = PanoramaPage_PlaceView.lt.ElementAt(ind);
                path = p.Path;
                BitmapImage tn = new BitmapImage();
                tn.UriSource = new Uri(path);
                currentimage.Source = tn;
                caption.Text = p.Caption;
                //MessageBox.Show(PanoramaPage_PlaceView.lt.ElementAt(0).Path);
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            int size = PanoramaPage_PlaceView.lt.Count;
            if (ind == 0) ind = size - 1;
            else ind = ind - 1;
            Photo p = PanoramaPage_PlaceView.lt.ElementAt(ind);
            path = p.Path;
            BitmapImage tn = new BitmapImage();
            tn.UriSource = new Uri(path);
            currentimage.Source = tn;

            caption.Text = p.Caption;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            int size = PanoramaPage_PlaceView.lt.Count;
            ind = (ind + 1) % size;
            Photo p = PanoramaPage_PlaceView.lt.ElementAt(ind);
            path = p.Path;
            BitmapImage tn = new BitmapImage();
            tn.UriSource = new Uri(path);
            currentimage.Source = tn;
            caption.Text = p.Caption;
        }

        private void currentimage_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            var x = e.DeltaManipulation.Translation.X;
            if (flag == false)
            {
                startpoint = Convert.ToInt32(x);
                flag = true;
            }
            else
            {

                int diff = Convert.ToInt32(x) - startpoint;
                //MessageBox.Show(Convert.ToString(diff));
                if (Math.Abs(diff) > 50)
                {
                    if (diff > 0)
                    {
                        ApplicationBarIconButton_Click(null, null);
                    }
                    else
                    {
                        ApplicationBarIconButton_Click_1(null, null);
                    }
                }
            }

        }

        private void currentimage_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
        }


    }
}