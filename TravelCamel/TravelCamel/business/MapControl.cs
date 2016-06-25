using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsPresentation;
using GMap.NET;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Travel_CamelMap
{
    class MapControl : GMapControl
    {
        public void addMarker(GMapMarker marker)
        {
           
          
            this.Markers.Add(marker);


        }

        public void delMarker(GMapMarker marker)
        {

            this.Markers.Remove(marker);


        }
    }

   
}
