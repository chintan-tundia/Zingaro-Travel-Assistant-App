using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinagaro_Travel_Assistant
{
    public class Place
    {



        public int PlaceId
        {
            get;
            set;
        }
        public string PlaceName
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public double latitude
        {
            get;
            set;
        }
        public double longitude
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public string ParentId
        {
            get;
            set;
        }
        public string ImagePath
        {
            get;
            set;
        }
        public Place(String placename, String imgpath)
        {
            PlaceName = placename;
            ImagePath = imgpath;
        }
        public Place() { }
        public Place(int PlaceId, string PlaceName, string Description, double latitude, double longitude, string ImagePath)
        {
            // TODO: Complete member initialization
            this.PlaceId = PlaceId;
            this.PlaceName = PlaceName;
            this.Description = Description;
            this.latitude = latitude;
            this.longitude = longitude;
            this.ImagePath = ImagePath;
        }


    }
}
