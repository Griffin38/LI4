using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET.WindowsPresentation;

namespace Travel_Camel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
  
      
   
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            this.comecar.Visibility = Visibility.Hidden;
            this.Planear.Visibility = Visibility.Hidden;
            this.Viagens.Visibility = Visibility.Hidden;
            MapLoad();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "Grifin e o Rei";
            this.comecar.Visibility = Visibility.Visible;
            this.Planear.Visibility = Visibility.Visible;
            this.Viagens.Visibility = Visibility.Visible;
        }
        private void Button_ClickPonto(object sender, RoutedEventArgs e)
        {
        }
        private void Button_ClickFim(object sender, RoutedEventArgs e)
        {
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {

            string cidade = cidadeS.Text;
           
            Desc.Text =  cidade  + Environment.NewLine +"è Lindo";
           mapControl2.SetPositionByKeywords(cidade);

            //markers 

        }

        private void MapLoad()
        {
          
            // Initialize map:
            mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl2.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl2.Zoom = 10;
            mapControl.Zoom = 15;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            mapControl.SetPositionByKeywords("Braga, Portugal");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    
    }

