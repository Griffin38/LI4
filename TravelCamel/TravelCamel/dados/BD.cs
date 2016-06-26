﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using TravelCamel.business;

namespace TravelCamel.dados
{
    class BD
    {
        private SqlConnection connection;


        public void connect()
        {
            connection = new SqlConnection("Server = localhost\\sqlexpress;Database=LI4;Integrated Security=SSPI;Trusted_Connection = yes;MultipleActiveResultSets=True;");

            try { connection.Open();
               
                // Pool A is created.
            } catch (SqlException er)
            {
                MessageBox.Show("Ligação nao foi feita, " + er.Message);}
            }

        public Cidade getCidade(string cidade)
        {
            Cidade b = new Cidade();
            int cidID = 0;
            HashSet<PontosInteresse> ret = new HashSet<PontosInteresse>();
            // Create the command
            SqlCommand command = new SqlCommand("SELECT idCidade FROM dbo.Cidade WHERE Nome = @0", connection);
            // Add the parameters.
            command.Parameters.Add(new SqlParameter("@0", cidade));
            try
            {
                // Create new SqlDataReader object and read data from the command.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        cidID = (int)reader[0];


                    }
                }
                if (cidID != 0) {  HashSet<PontosInteresse> au= getPontos(cidID);  b = new Cidade(cidade,au); }
            }
            catch (SqlException er)
            {
                MessageBox.Show("There was an error reported by SQL Server, " + er.Message);
            }
          

            return b;
        }
    public HashSet<PontosInteresse> getPontos(int cidID)
        {
            HashSet<PontosInteresse> ret = new HashSet<PontosInteresse>();
                    // Create the command
                    SqlCommand command2 = new SqlCommand("SELECT * FROM dbo.Pontos_Interesse WHERE idCidade = @0", connection);
                    // Add the parameters.
                    command2.Parameters.Add(new SqlParameter("@0",cidID.ToString()));

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader2.Read())
                        {
                    decimal val6 =(decimal) reader2[6],val5 =(decimal) reader2[5];
                   
                    float la = (float)val6, lo = (float)val5;
                            PontosInteresse a = new PontosInteresse(la, lo, (string)reader2[1], (string)reader2[2], (string)reader2[4]);
                            ret.Add(a);
                   

                }
                }

            return ret;

        }

        public Boolean login(string Nome, string password)
        {
            Boolean log = false;
            SqlCommand command = new SqlCommand("SELECT idUtilizador FROM Utilizador WHERE NickName = @0 and PassWord = @1", connection);
            // Add the parameters.
            command.Parameters.Add(new SqlParameter("@0",Nome));
            command.Parameters.Add(new SqlParameter("@1",password));
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                        log = true;


                    }
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("Dados Incorrectos, " + er.Message);

            }



            return log;
        }
        public String getPais(int idPAis)
        {
            string ret = "unknown";
            SqlCommand command = new SqlCommand("select Nome from dbo.Pais where IdPais = @0", connection);
            // Add the parameters.
            command.Parameters.Add(new SqlParameter("@0", idPAis));
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                        ret =(string) reader[0];
                    }
                }
            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }
            return ret;
        }


        public PontosInteresse getPonto(int id)
        {

            PontosInteresse ret = new PontosInteresse();
            
            SqlCommand command1 = new SqlCommand("SELECT * FROM dbo.Pontos_Interesse where idPonto = @0", connection);
            command1.Parameters.Add(new SqlParameter("@0", id));


            using (SqlDataReader reader = command1.ExecuteReader())
            {
                // while there is another record present
                if (reader.Read())
                {

                    decimal val6 = (decimal)reader[6], val5 = (decimal)reader[5];

                    float la = (float)val6, lo = (float)val5;
                    ret = new PontosInteresse(la, lo, (string)reader[1], reader[2].ToString(), reader[4].ToString());

                }
            }

            return ret;
        }

        public IDictionary<string, Viagens> realizadasUser(int userID)
        {
            IDictionary<string, Viagens> ret = new Dictionary<string, Viagens>();
            HashSet<PontosInteresse> a = new HashSet<PontosInteresse>();
            Viagens b = new Viagens();
            SqlCommand command1 = new SqlCommand("SELECT idViagem,Nome FROM dbo.Viagem WHERE idUtilizador = @0 and Datafim < GETDATE()", connection);
            SqlCommand command2 = new SqlCommand("SELECT idPonto FROM dbo.Informacoes WHERE idViagem = @0 and DataObservacao IS NULL", connection);

            command1.Parameters.Add(new SqlParameter("@0", userID));
            try
            {
               
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {   a = new HashSet<PontosInteresse>(); ;
                        command2.Parameters.Add(new SqlParameter("@0", reader[0]));
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {

                            while (reader2.Read())
                            {
                                
                                PontosInteresse p = getPonto((int) reader2[0]);
                                a.Add(p);
                            }
                           }




                        b = new Viagens((string)reader[1],a);
                        ret.Add((string)reader[1], b);
                    }
                }



            }
            catch (Exception er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }

            return ret;
        }
        public IDictionary<string, Viagens> planeadasUser(int userID)
        {
            IDictionary<string, Viagens> ret = new Dictionary<string, Viagens>();
            HashSet<PontosInteresse> a = new HashSet<PontosInteresse>();
            Viagens b = new Viagens();
      
            SqlCommand command1 = new SqlCommand("SELECT idViagem,Nome FROM dbo.Viagem WHERE idUtilizador = @0 and DataInicio > GETDATE()", connection);
            SqlCommand command2 = new SqlCommand("SELECT idPonto FROM dbo.Informacoes WHERE idViagem = @0 and DataObservacao IS NULL", connection);
            command1.Parameters.Add(new SqlParameter("@0", userID));
            try
            {
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        a = new HashSet<PontosInteresse>(); ;
                        command2.Parameters.Add(new SqlParameter("@0", reader[0]));
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {

                            while (reader2.Read())
                            {

                                PontosInteresse p = getPonto((int)reader2[0]);
                                a.Add(p);
                            }
                        }




                        b = new Viagens((string)reader[1], a);
                        ret.Add((string)reader[1],b);
                    }
                }



            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }

            return ret;

        }

        public Utilizador loggedIN(string nick)
        { int id = 0;
            string Nome;
            string Nick;
            string Email;
         
            Utilizador ret = new Utilizador();
            IDictionary<string, Viagens> realizadasT = new Dictionary<string, Viagens>();
            IDictionary<string, Viagens> planeadasT = new  Dictionary< string, Viagens > ();

            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Utilizador WHERE NickName = @0", connection);
       
            // Add the parameters.
            command.Parameters.Add(new SqlParameter("@0", nick));
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                        id = (int)reader[0];
                        Nome = (string)reader[1];
                        Nick = (string)reader[2];
                        Email = (string)reader[3];
                        
                       
                        realizadasT = realizadasUser(id);
                        planeadasT = planeadasUser(id);

                        ret = new Utilizador(Nome, Nick, Email, "nabo", realizadasT, planeadasT);
                    }
                }
               

               
            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }

           
            return ret;
        }

        public int NFotos(int v , int p)
        {
            int ret= 0;
            SqlCommand command1 = new SqlCommand("SELECT COUNT(id) FROM Informacoes WHERE idViagem = @0 and idPonto = @1 and TipoInfor = 1 ", connection);
            command1.Parameters.Add(new SqlParameter("@0", v));
            command1.Parameters.Add(new SqlParameter("@1", p));
            try
            {
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                        ret += (int)reader[0];
                    }
                }



            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }
            return ret;
        }
        public int Nnotas(int v, int p)
        {
            int ret = 0;
            SqlCommand command1 = new SqlCommand("SELECT COUNT(id) FROM Informacoes WHERE idViagem = @0 and idPonto = @1 and TipoInfor = 2 ", connection);
            command1.Parameters.Add(new SqlParameter("@0", v));
            command1.Parameters.Add(new SqlParameter("@1", p));
            try
            {
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                        ret += (int)reader[0];
                    }
                }



            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }
            return ret;


        }
        public string InfPV(string viagem,string ponto)
        {
            String ret = "";
            int a = 0;
            int b = 0;
            SqlCommand command1 = new SqlCommand("SELECT idViagem FROM dbo.Viagem WHERE Nome = @0 ", connection);
            SqlCommand command2 = new SqlCommand("SELECT idPonto FROM dbo.Pontos_Interesse WHERE Nome = @0 ", connection);
            command1.Parameters.Add(new SqlParameter("@0", viagem));
            command2.Parameters.Add(new SqlParameter("@0", ponto));
            try
            {
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    // while there is another record present
                    if (reader.Read())
                    {
                       a= (int)reader[0];
                      
                    }
                 

                }
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {

                    if (reader2.Read())
                    {

                        b = (int)reader2[0];
                    }
                }

                ret = "Notas " + Nnotas(a, b) + "\nFotos " + NFotos(a, b);
            }
            catch (SqlException er)
            {
                MessageBox.Show("Erro, " + er.Message);

            }
            return ret;
        }
        //construtor
        public BD()
        {
            connect();

        }
    }
    }

