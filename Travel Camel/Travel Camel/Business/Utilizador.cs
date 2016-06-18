using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

public class Utilizador
{
    private String nome;
    private String palavra_Passe;
    private String nick_Name;
    private String email;
    private String pais;
    private ArrayList viagens;
    private ArrayList avaliacoes;
    private ArrayList pontosGuardados;
   



    public Utilizador()
	{
        this.nome = "";
        this.email = "";
        this.nick_Name = "";
        this.palavra_Passe = "";
        this.avaliacoes = new ArrayList();
        this.pontosGuardados = new ArrayList();
        this.viagens = new ArrayList();
        this.pais = "";
	}


    public Utilizador(String nome, String palavra_Passe, String nick_Name, String email,String pais, ArrayList avaliacoes, ArrayList viagens, ArrayList pontos) {
        this.nome = nome;
        this.palavra_Passe = palavra_Passe;
        this.email = email;
        this.nick_Name = nick_Name;
        this.pais = pais;
        this.viagens = new ArrayList();
        this.avaliacoes = new ArrayList();
        this.pontosGuardados = new ArrayList();
        foreach (Object o in viagens )
        {
            this.viagens.add(o);
        }

        foreach (Object o in avaliacoes)
        {
            this.avaliacoe.add(o);
        }

        foreach (Object o in pontos)
        {
            this.pontosGuardados.add(o);
        }
    }

   



    


}
