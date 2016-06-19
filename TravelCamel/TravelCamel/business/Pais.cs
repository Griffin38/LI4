using System;
using System.Collections;
using System.Collections.Generic;
namespace TravelCamel.business { 
public class Pais
{
    public string Nome { get; set; }
    public HashSet<Cidade> cidades;


    public Pais()
    {
        Nome = "unknown";
        cidades = new HashSet<Cidade>();
    }
    public Pais(string Nom, HashSet<Cidade> Po)
    {
        Nome = Nom;
        IEnumerator enumerator = Po.GetEnumerator();
        while (enumerator.MoveNext())
        {
            object item = enumerator.Current;
            cidades.Add((Cidade)item);

        }
    }
}
}