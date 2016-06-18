using System;


    public class PontosInteresse
    {
        // Class members:
        // Property.
        private int NumberV { get; set; }
    private float lati { get; set; }
    private float longi { get; set; }
    public string Nome { get; set; }
        public float score { get; set; }
        public string Mapa { get; set; }
    public string desc { get; set; }

    // Method.


    // Instance Constructor.
    public PontosInteresse()
    {
        Nome = "unknown";
        Mapa = "unknown";
        desc = "unknown";
        NumberV = 0;
        score = 0;
        lati = 0;
        longi = 0;

        }
    public PontosInteresse(int n, float sc, ,float la, float lo, string no,string ma,string des)
    {
        Nome = no;
        Mapa = ma;
        NumberV = n;
        score = sc;
        lati = la;
        longi = lo;
        desc= des;
    }
}
