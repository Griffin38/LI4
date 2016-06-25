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
        private BD con;
        private Cidade cc;
       private Utilizador uu;
        private IDictionary<string, GMapMarker>  mapM1;
        private IDictionary<string, GMapMarker> mapM2;
        private IDictionary<string, GMapMarker> mapM3;
        public Page1()
        {
            InitializeComponent();
        
         this.comecar.Visibility = Visibility.Hidden;
           this.Planear.Visibility = Visibility.Hidden;
           this.Viagens.Visibility = Visibility.Hidden;
           MapLoad();
            con = new BD();
            
       }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

           
        }

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

        private void setMap(Viagens v)
        {
            int i = 0; 
            foreach (PontosInteresse p in v.Pontos){
              
                
                GMapMarker marker = new GMapMarker(new PointLatLng(p.longi,p.lati));
              
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
              
                mapM3.Add(p.Nome, marker);
                mapControl3.addMarker(marker);

                if (i == 0) { mapControl3.SetPositionByKeywords(p.Mapa); i++;  }

            }



        }
        private void preencheListas()
        {
            int i = 0;
            foreach (KeyValuePair<string, Viagens> kvp in uu.realizadas)
            {
                ListaCompletas.Items.Add(kvp.Key);
                if(i==0)
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
               
                    GMapMarker marker = new GMapMarker(new PointLatLng(p.longi,p.lati));
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
          foreach(PontosInteresse p in cc.Pontos){
                ListaC.Items.Add(p.Nome);

            }
            mapControl2.SetPositionByKeywords(cidad);

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
            this.mapM1 = new Dictionary<string, GMapMarker>();
            this.mapM2 = new Dictionary<string, GMapMarker>();
            this.mapM3 = new Dictionary<string, GMapMarker>();
        }

        private void ListBox_SelectionChangedComp(object sender, SelectionChangedEventArgs e)
        {

        }

        
  private void ListC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Boolean f = true;
            IEnumerator enumerator = cc.Pontos.GetEnumerator();
            while (enumerator.MoveNext()&& f)
            {
                object item = enumerator.Current;
                PontosInteresse p = (PontosInteresse)item;
                if(p.Nome.Equals(ListaC.SelectedItem))
                {
                    Desc.Text = p.desc;
                    f = false;
                }

            }
           

        }
    }


}


