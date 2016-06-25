using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelCamel.dados;
using TravelCamel.business;
using System.Collections;
using GMap.NET.WindowsPresentation;
using GMap.NET;

namespace TravelCamel
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {

        //vars
        private BD con;
        private Cidade cc;
       private Utilizador uu;
        private IDictionary<string, GMapMarker>  mapM1;
        private IDictionary<string, GMapMarker> mapM2;
        private IDictionary<string, GMapMarker> mapM3;

        //inicializar ------------------------------

        public Page1()
        {
            InitializeComponent();
        
         this.comecar.Visibility = Visibility.Hidden;
           this.Planear.Visibility = Visibility.Hidden;
           this.Viagens.Visibility = Visibility.Hidden;
           MapLoad();
            con = new BD();
            
       }


        private void preencheListas()
        {
            int i = 0;
            foreach (KeyValuePair<string, Viagens> kvp in uu.realizadas)
            {
                ListaCompletas.Items.Add(kvp.Key);
                if (i == 0)
                {
                    setMap(kvp.Value);
                    i++;
                }

            }
            i = 0;
            foreach (KeyValuePair<string, Viagens> kvp in uu.planeadas)
            {
                ListaPlaneadas.Items.Add(kvp.Key);
                if (i == 0)
                {
                    setMap3(kvp.Value);
                    i++;
                }

            }



        }

        private void MapLoad()
        {

            // Initialize map:
            mapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl2.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl3.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            mapControl2.Zoom = 10;
            mapControl.Zoom = 15;
            mapControl3.Zoom = 15;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            mapControl.SetPositionByKeywords("Braga, Portugal");
            this.mapM1 = new Dictionary<string, GMapMarker>();
            this.mapM2 = new Dictionary<string, GMapMarker>();
            this.mapM3 = new Dictionary<string, GMapMarker>();
        }


        //click ------------------------------------------------------------------------------------------

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string a, b;
            a = username.Text;
            b = password.Password;

            if (con.login(a, b))
            {
                uu = con.loggedIN(a);
               
                preencheListas();
                this.comecar.Visibility = Visibility.Visible;
                this.Planear.Visibility = Visibility.Visible;
                this.Viagens.Visibility = Visibility.Visible;
                username.Visibility = Visibility.Hidden;
                password.Visibility = Visibility.Hidden;
                loginb.Visibility = Visibility.Hidden;
                logoutb.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("Dados de Login Errados");
        }


        private void Button_Click2(object sender, RoutedEventArgs e)
        {


        }

        private void Button_ClickPonto(object sender, RoutedEventArgs e)
        {
            Boolean f = true;
            IEnumerator enumerator = cc.Pontos.GetEnumerator();
            while (enumerator.MoveNext() && f)
            {
                object item = enumerator.Current;
                PontosInteresse p = (PontosInteresse)item;
                if (p.Nome.Equals(ListaC.SelectedItem))
                {

                    GMapMarker marker = new GMapMarker(new PointLatLng(p.longi, p.lati));
                    marker.Shape = new Ellipse
                    {  
                        Fill = Brushes.Yellow,
                        Width = 10,
                        Height = 20,
                        Stroke = Brushes.Red,
                        StrokeThickness = 1.5
                       
                    };
                    marker.Shape.Uid = ListaC.SelectedItem.ToString();
                    mapControl2.addMarker(marker);
                    mapM2.Add(ListaC.SelectedItem.ToString(), marker);





                    f = false;
                }

            }

        }
        private void Button_ClickFim(object sender, RoutedEventArgs e)
        {
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            ListaC.Items.Clear();
            string cidad = cidadeS.Text;
            cc = con.getCidade(cidad);
            foreach (PontosInteresse p in cc.Pontos)
            {
                ListaC.Items.Add(p.Nome);

            }
            mapControl2.SetPositionByKeywords(cidad);

            //markers 
            
        }


        private void Button_ClickM1(object sender, RoutedEventArgs e)
        { Shape a = (Shape)sender;
            //notas / fotos 
            MessageBox.Show( a.Uid);
        }
        private void Button_ClickM3(object sender, RoutedEventArgs e)
        {
            Shape a = (Shape)sender;
            //pontos desc
            
           
            MessageBox.Show(a.Uid);
        }

        //Listas ------------------------------------------------------------------------------------------



        private void ListBox_SelectionChangedComp(object sender, SelectionChangedEventArgs e)
        {
            //reset map
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM1)
            {
                mapControl.delMarker(kvp.Value);

            }
            mapM1 = new Dictionary<string, GMapMarker>();
            //new setMap

            setMap(uu.realizadas[ListaCompletas.SelectedItem.ToString()]);

        }


        private void ListC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boolean f = true;
            IEnumerator enumerator = cc.Pontos.GetEnumerator();
            while (enumerator.MoveNext() && f)
            {
                object item = enumerator.Current;
                PontosInteresse p = (PontosInteresse)item;
                if (p.Nome.Equals(ListaC.SelectedItem))
                {
                    Desc.Text = p.desc;
                    f = false;
                }

            }


        }
        private void ListBox_SelectionChangedPlan(object sender, SelectionChangedEventArgs e)
        {
            //reset map
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM3)
             {
                mapControl3.delMarker(kvp.Value);

            }
            mapM3 = new Dictionary<string, GMapMarker>();
            //new setMap

            setMap3(uu.planeadas[ListaPlaneadas.SelectedItem.ToString()]);

        }

        //Mapas ------------------------------------------------------------------------------------------


        private void setMap(Viagens v)
        {
            int i = 0; 
            foreach (PontosInteresse p in v.Pontos){

                
                GMapMarker marker = new GMapMarker(new PointLatLng(p.longi,p.lati));


                marker.Shape = new Ellipse
                {
                    Fill = Brushes.Yellow,
                    Width = 10,
                    Height = 20,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1.5
                };
                marker.Shape.MouseLeftButtonDown += Button_ClickM1;
                marker.Shape.Uid = p.Nome;

                mapM1.Add(p.Nome, marker);
                mapControl.addMarker(marker);
                    
                if (i == 0) { mapControl.SetPositionByKeywords(p.Mapa); i++; Notas.Text = p.Mapa; }

            }

        }



        private void setMap3(Viagens v)
        {

            int i = 0;
            foreach (PontosInteresse p in v.Pontos)
            {
              
                GMapMarker marker = new GMapMarker(new PointLatLng(p.longi, p.lati));


                marker.Shape = new Ellipse
                {
                    Fill = Brushes.Yellow,
                    Width = 10,
                    Height = 20,
                    Stroke = Brushes.Red,
                    StrokeThickness = 1.5
                };
                marker.Shape.MouseLeftButtonDown += Button_ClickM3;
                marker.Shape.Uid = p.Nome;
                mapM3.Add(p.Nome, marker);
                mapControl3.addMarker(marker);

                if (i == 0) { mapControl3.SetPositionByKeywords(p.Mapa); i++; desc2.Text = p.Mapa; }

            }



        }



      

       


    }


}


