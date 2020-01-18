using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace Zinagaro_Travel_Assistant
{
    public partial class PanoramaPage_PlaceView : PhoneApplicationPage
    {
        public static List<Photo> lt = new List<Photo>();
        string PlaceID;
        string imgpath1;
        string currentPlace
        {
            get;
            set;
        }

        public PanoramaPage_PlaceView()
        {
            InitializeComponent();
                                
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("id"))
            {
                string val = NavigationContext.QueryString["id"];
                PlaceID = val;
                loadImages(PlaceID);
            }
            if (NavigationContext.QueryString.ContainsKey("placename"))
            {
                string val = NavigationContext.QueryString["placename"];
                Pan.Title = val;
            }
            if (NavigationContext.QueryString.ContainsKey("description"))
            {
                string val = NavigationContext.QueryString["description"];
                Description.Text = val;
            }
            if (NavigationContext.QueryString.ContainsKey("latitude"))
            {
                string val1 = NavigationContext.QueryString["latitude"];
                //lat.Text = val;
                if (NavigationContext.QueryString.ContainsKey("longitude"))
                {
                    string val2 = NavigationContext.QueryString["longitude"];
                    //lng.Text = val;
                    //map1.Center = new GeoCoordinate(Convert.ToDouble(val1),Convert.ToDouble(val2));
                }
                
            }
            
            
            if (NavigationContext.QueryString.ContainsKey("imgpath"))
            {
                imgpath1 = NavigationContext.QueryString["imgpath"];
                                
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(
                    new Uri( imgpath1));
                myBrush.ImageSource = image.Source;
                myBrush.Opacity = 0.7;                
                Grid grid = new Grid();
                LayoutRoot.Background = myBrush;
            }
            


        }
        public void loadImages(string id)
        {
            String myUrl = "http://zingaro.site11.com/web/pages/getAllPlacePhotosJSON.php?placeid="+id;
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri(myUrl), UriKind.Relative);
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
        }
        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                
                var rootObject = JsonConvert.DeserializeObject<List<Photo>>(e.Result);
                lt = new List<Photo>();               
                lt.Add(new Photo(0, 0, 1, Pan.Title.ToString(), (imgpath1) , 0));
                int i = 1;
                foreach (var photo in rootObject)
                {
                    int pid, uid,blocked;
                    pid = Convert.ToInt32 (photo.PhotoId);
                    uid = Convert.ToInt32(photo.UserId);
                    blocked = Convert.ToInt32(photo.blocked);                    
                    lt.Add(new Photo(i,pid,uid,photo.Caption,"http://zingaro.site11.com/web/pages/" + photo.Path,blocked));
                    i++;
                }
                lstPhotos.ItemsSource = lt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
        }
        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selected = (sender as Image);
            string path = (selected.Source as BitmapImage).UriSource.ToString();
            int i = 0;
            foreach (var photo in lt)
            {
                if(path==photo.Path)
                {
                    break;
                }
                i++;
            }            
            NavigationService.Navigate(new Uri("/Pivot_ImageGallery.xaml?id="+i, UriKind.RelativeOrAbsolute));
        }
    }
}