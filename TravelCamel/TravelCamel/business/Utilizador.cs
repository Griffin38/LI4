using System;
using System.Collections.Generic;
namespace TravelCamel.business
{
    public class Utilizador
    {
        public string Nome { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        IDictionary<string, Viagens> realizadas;
        IDictionary<string, Viagens> planeadas;

        //
        public Utilizador()
        {
            Nome = Nick = Email = Pais = "unkown";
            realizadas = new Dictionary<string, Viagens>();
            planeadas = new Dictionary<string, Viagens>();

        }

        public Utilizador(string no, string ni, string em, string pa, IDictionary<string, Viagens> re, IDictionary<string, Viagens> pl)
        {
            Nome = no;
            Nick = ni;
            Email = em;
            Pais = pa;


            foreach (KeyValuePair<string, Viagens> kvp in re)
            {
                realizadas.Add(kvp.Key, kvp.Value);


            }


            foreach (KeyValuePair<string, Viagens> kvq in pl)
            {
                planeadas.Add(kvq.Key, kvq.Value);


            }


        }
    }
}