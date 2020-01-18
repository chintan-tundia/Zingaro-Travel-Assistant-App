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
    public partial class Pivot_ImageGallery : PhoneApplicationPage
    {
        public Pivot_ImageGallery()
        {
            InitializeComponent();
        }
        string path;
        int ind;

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
                //currentimage.Source = tn;
                //caption.Text = p.Caption;
                //MessageBox.Show(PanoramaPage_PlaceView.lt.ElementAt(0).Path);
            }
            
            int len=PanoramaPage_PlaceView.lt.Count;           
            for (int i = 0; i < len; i++)
            {
                PivotItem pivotItem = new PivotItem();
                //pivotItem.Header = i.ToString();
                Grid grid = new Grid();                
                BitmapImage img = new BitmapImage();
                Photo p = PanoramaPage_PlaceView.lt.ElementAt(i);
                string path = p.Path;
                img.UriSource = new Uri(path);
                Image im = new Image();
                im.Source = img;
                TextBlock tb = new TextBlock();
                tb.Text = p.Caption;                
                tb.FontSize = 30;
                tb.TextWrapping = TextWrapping.Wrap;
                grid.Children.Insert(0, im);
                grid.Children.Insert(1, tb);
             

                pivotItem.Content = grid;         
                mainPivot.Items.Add(pivotItem);          
            }
            
        }
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            int size = PanoramaPage_PlaceView.lt.Count;            
            if (ind == 0) ind = size - 1;
            else ind = ind - 1;           
            mainPivot.SelectedIndex = ind;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            int size = PanoramaPage_PlaceView.lt.Count;            
            ind = (ind + 1) % size;
            mainPivot.SelectedIndex = ind;
           
        }
    }
}