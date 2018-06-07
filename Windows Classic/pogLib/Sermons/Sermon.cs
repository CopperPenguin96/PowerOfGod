using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pogLib.Sermons
{
    public class Sermon
    {
        public string Name;
        public string AirDate = "01/01/1990";
        public string ID;
        public string Speaker = "Unidentified";

        public DateTime AirDateDT()
        {
            if (AirDate == "01/01/1990") throw new ArgumentException("AirDate: " + AirDate);
            return DateTime.Parse(AirDate);
        }

        
    }
}
