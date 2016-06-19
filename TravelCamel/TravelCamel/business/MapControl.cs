using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET.WindowsPresentation;
using GMap.NET;

namespace Travel_CamelMap
{
    class MapControl : GMapControl
    {
        public void addMarker(float lat, float longi)
        {

            GMapMarker marker = new GMapMarker(new PointLatLng(lat, longi));
            this.Markers.Add(marker);


        }
    }

   
}
