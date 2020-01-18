using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;

namespace Zinagaro_Travel_Assistant
{
    public partial class DiscoverStartPage : PhoneApplicationPage
    {
        public static List<Place> lt = new List<Place>();
        public DiscoverStartPage()
        {
            InitializeComponent();
            loadPlaces();
        }
        public void loadPlaces()
        {
            String myUrl = "http://zingaro.site11.com/web/pages/getAllPlacesJSON.php";
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri(myUrl), UriKind.Relative);
            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
        }
        private void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //try
            {
                var rootObject = JsonConvert.DeserializeObject<List<Place>>(e.Result);
                lt = new List<Place>();
                foreach (var place in rootObject)
                {
                    double lat, lng;
                    lat = Convert.ToDouble(place.latitude);
                    lng = Convert.ToDouble(place.longitude);
                    lt.Add(new Place(place.PlaceId, place.PlaceName, place.Description, lat, lng, "http://zingaro.site11.com/web/pages/" + place.ImagePath));
                }
                lstplaces.ItemsSource = lt;
            }
            //catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }




        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var selected = (sender as StackPanel);
            string s = (selected.Children.ElementAt(0) as TextBlock).Text;
            string desc = "";
            string imagepath = "";
            double lat = 0, lng = 0;
            string id="";
            foreach (Place obj in lt)
            {
                if (obj.PlaceName.Equals(s))
                {
                    id = Convert.ToString(obj.PlaceId);    
                    desc = obj.Description;
                    lat = Convert.ToDouble(obj.latitude);
                    lng = Convert.ToDouble(obj.latitude);
                    imagepath = obj.ImagePath;
                    break;
                }
            }
            NavigationService.Navigate(new Uri("/PanoramaPage_PlaceView.xaml?id="+ id +"&placename=" + s + "&description=" + desc + "&latitude=" + lat + "&longitude=" + lng + "&imgpath=" + imagepath, UriKind.Relative));
        }

    }
}