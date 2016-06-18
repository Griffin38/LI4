using System;
using System.Collections;
using System.Collections.Generic;

public class Cidade
{
    public string Nome { get; set; }
    public HashSet<PontosInteresse> Pontos;


    public Cidade()
	{
        Nome = "unknown";
        Pontos = new HashSet<PontosInteresse>();
	}
    public Cidade(string Nom, HashSet<PontosInteresse> Po)
    {
        Nome = Nom;
        IEnumerator enumerator = Po.GetEnumerator();
        while (enumerator.MoveNext())
        {
            object item = enumerator.Current;
            Pontos.Add((PontosInteresse)item);
            
        }
    }
}
