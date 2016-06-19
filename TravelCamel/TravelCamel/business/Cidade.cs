using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace TravelCamel.business { 
public class Cidade
{
    public string Nome { get; set; }
    public HashSet<PontosInteresse> Pontos { get; set; }


    public Cidade()
    {
        Nome = "unknown";
        Pontos = new HashSet<PontosInteresse>();
    }
    public Cidade(string Nom, HashSet<PontosInteresse> Po)
    {
        Nome = Nom;

            Pontos = new HashSet<PontosInteresse>();

            foreach(PontosInteresse p in Po)
            {
                 Pontos.Add(p);
               
            }
       
    }
}
}