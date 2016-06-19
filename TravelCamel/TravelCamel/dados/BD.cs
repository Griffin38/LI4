using System;
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
            connection = new SqlConnection("Server = localhost\\sqlexpress;Database=LI4;Integrated Security=SSPI;Trusted_Connection = yes;");

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

        public BD()
        {
            connect();

        }
    }
    }

