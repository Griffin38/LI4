using System;


    public class PontosInteresse
    {
        // Class members:
        // Property.
    
    private float lati { get; set; }
    private float longi { get; set; }
    public string Nome { get; set; }
        
        public string Mapa { get; set; }
    public string desc { get; set; }

    // Method.


    // Instance Constructor.
    public PontosInteresse()
    {
        Nome = "unknown";
        Mapa = "unknown";
        desc = "unknown";
        
      
        lati = 0;
        longi = 0;

        }
    public PontosInteresse( float la, float lo, string no,string ma,string des)
    {
        Nome = no;
        Mapa = ma;
      
        lati = la;
        longi = lo;
        desc= des;
    }
}
