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

    public HashSet<PontosInteresse> getPontos(string cidade)
        {
            int cidID = 0;
            HashSet<PontosInteresse> ret = new HashSet<PontosInteresse>();
            // Create the command
            SqlCommand command = new SqlCommand("SELECT id FROM Cidade WHERE Nome = @first", connection);
            // Add the parameters.
            command.Parameters.Add(new SqlParameter(cidade, 0));
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
            }
            catch (SqlException er)
            {
                MessageBox.Show("There was an error reported by SQL Server, " + er.Message);
            }
                if (cidID != 0)
                {
                    // Create the command
                    SqlCommand command2 = new SqlCommand("SELECT * FROM Ponto_Interesse WHERE Cidade_idCidade = @first", connection);
                    // Add the parameters.
                    command2.Parameters.Add(new SqlParameter(cidID.ToString(), 0));

                    // Create new SqlDataReader object and read data from the command.
                    using (SqlDataReader reader2 = command2.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader2.Read())
                        {
                            PontosInteresse a = new PontosInteresse(float.Parse((string)reader2[5]), float.Parse((string)reader2[4]), (string)reader2[1], (string)reader2[2], (string)reader2[2]);
                            ret.Add(a);

                        }
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

