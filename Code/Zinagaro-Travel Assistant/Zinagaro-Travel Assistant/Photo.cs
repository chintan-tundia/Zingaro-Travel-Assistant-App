using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zinagaro_Travel_Assistant
{
    public class Photo
    {       

        public int PhotoId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
        public string Caption
        {
            get;
            set;
        }
        public string Path
        {
            get;
            set;
        }
        public int blocked
        {
            get;
            set;
        }
        public int ObjectId;
        public Photo() { }

        public Photo(int ObjectId,int PhotoId,int UserId,string Caption,string Path,int blocked)
        {
            // TODO: Complete member initialization
            this.ObjectId = ObjectId;
            this.PhotoId = PhotoId;
            this.UserId = UserId;
            this.Caption = Caption;
            this.Path = Path;
            this.blocked = blocked;
        }

    }
}
