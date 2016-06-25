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
              marker.Shape = new Ellipse
             { Fill = Brushes.Yellow,
             Width = 10,
                Height = 20,
                 Stroke = Brushes.Red,
                 StrokeThickness = 1.5
          };
          
            this.Markers.Add(marker);


        }
    }

   
}
