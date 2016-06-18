using System;
using System.Collections;
using System.Collections.Generic;

public class Viagens
{

    public string Nome { get; set; }
    public HashSet<PontosInteresse> Pontos;
    public DateTime inicio { get; set; }
    public DateTime fim { get; set; }
    /// <summary>
    ///  notas?
    ///  
    /// </summary>

    public Viagens()
	{
        Nome = "unknown";
        Pontos = new HashSet<PontosInteresse>();
	}

    public Viagens(string Nom, HashSet<PontosInteresse> Po)
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
