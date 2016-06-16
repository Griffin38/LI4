using System;

public class Utilizador
{
    private String nome;
    private String palavra_Passe;
    private String nick_Name;
    private String email;
    private ArrayList<Viagens> viagens;


    public Utilizador()
	{
        this.nome = "";
        this.email = "";
        this.nick_Name = "";
        this.palavra_Passe = "";
	}


    public Utilizador(String nome, String palavra_Passe, String nick_Name, String email) {
        this.nome = nome;
        this.palavra_Passe = palavra_Passe;
        this.email = email;
        this.nick_Name = nick_Name;
    }

    public Utilizador(Utilizador p)
    {
        this.email = p.getEmail();
        this.palavra_Passe = p.getPassWord();
        this.nome = p.getNome();
        this.nick_Name = p.getNickName();
    }

    public String getEmail() {
        return this.email;

    }


    public String getNickName()
    {
        return this.nick_Name;

    }


    public String getPassWord()
    {
        return this.palavra_Passe;


    }

    public String getNome()
    {
        return this.nome;

    }


    public override bool Equals(Object obj)
    {
        // Check for null values and compare run-time types.
        if (obj == null || GetType() != obj.GetType())
            return false;

        Utilizador p = (Utilizador)obj;
        return (this.nome.Equals(p.getNome()) && (this.nick_Name.Equals(p.getNickName()))  && this.email.Equals(p.getEmail()) && this.palavra_Passe.Equals(p.getPassWord()));
    }



}
