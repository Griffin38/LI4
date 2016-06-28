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

        private void reset()
        {

        
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM1)
            {
                mapControl.delMarker(kvp.Value);
            }
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM2)
            {
                mapControl2.delMarker(kvp.Value);
            }
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM3)
            {
                mapControl3.delMarker(kvp.Value);
            }
            ListaCompletas.Items.Clear();
            ListaPlaneadas.Items.Clear();
            ListaC.Items.Clear();
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
            this.comecar.Visibility = Visibility.Hidden;
            this.Planear.Visibility = Visibility.Hidden;
            this.Viagens.Visibility = Visibility.Hidden;
            username.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Visible;
            password.Password = "";
            loginb.Visibility = Visibility.Visible;
            logoutb.Visibility = Visibility.Hidden;
            uu = new Utilizador();
            reset();
         
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
                    try { 
                    mapM2.Add(ListaC.SelectedItem.ToString(), marker);
                    }catch(Exception er)
                    { MessageBox.Show(er.ToString()); }




                    f = false;
                }

            }

        }
        private void Button_ClickFim(object sender, RoutedEventArgs e)
        {
            HashSet<String> a = new HashSet<string>();
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM1)
             {

                a.Add(kvp.Key);
            }

            String nomeV = NomeV.Text.ToString();
            DateTime datai = Convert.ToDateTime(DataI.Text.ToString());
            HashSet<String> pontos = new HashSet<string>();
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM2)
            {
                pontos.Add(kvp.Key);

            }
                
                con.NovaViagem(uu.Nome,nomeV,datai,pontos);
            foreach (KeyValuePair<string, GMapMarker> kvp in mapM3)
            {
                mapControl3.delMarker(kvp.Value);
            }
         
         
            reset();

            uu = con.loggedIN(uu.Nick);
            preencheListas();
            //popup perguntar nome e data de inicio
            //     -   -    ok cancelar
            //mandar para BD para criar nova viagem e adicionar os pontos (Nome,a,data)
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

            
            
        }


        private void Button_ClickM1(object sender, RoutedEventArgs e)
        {
         
            Shape a = (Shape)sender;
            //pontos 
            if (ListaCompletas.SelectedItem == null) { ListaCompletas.SelectedItem = ListaCompletas.Items.GetItemAt(0); }
            Viagens b = uu.realizadas[ListaCompletas.SelectedItem.ToString()];
                foreach (PontosInteresse c in b.Pontos)
                {
                    if (c.Nome.Equals(a.Uid))
                    {

                    Notas.Text = con.InfPV(b.Nome, c.Nome);
                      
                      
                        break;
                    }

               
            }
        }
        private void Button_ClickM3(object sender, RoutedEventArgs e)
        {

            Boolean br = false;
            Shape a = (Shape)sender;
            //pontos desc
            foreach (KeyValuePair<string, Viagens> kvp in uu.planeadas)
            {
                foreach (PontosInteresse b in kvp.Value.Pontos)
                {
                    if (b.Nome.Equals(a.Uid))
                    {
                        desc2.Text = b.desc;
                        br = true;
                        break;
                    }

                }
                if (br) break;
            }


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

            if (ListaCompletas.SelectedItem != null) setMap(uu.realizadas[ListaCompletas.SelectedItem.ToString()]);

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

            if (ListaPlaneadas.SelectedItem != null)  setMap3(uu.planeadas[ListaPlaneadas.SelectedItem.ToString()]);

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
                    
                if (i == 0) { mapControl.SetPositionByKeywords(p.Mapa); i++;}

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

                if (i == 0) { mapControl3.SetPositionByKeywords(p.Mapa); i++;}

            }



        }



      

       


    }


}


