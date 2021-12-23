using GestioneSpese.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public static class ConnectedMode
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Spesa> VisualizzaSpeseApprovate()
        {
            using (SqlConnection connection = new SqlConnection(connectionStringSQL))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Spese where Approvato='True'";

                SqlDataReader reader = command.ExecuteReader();

                List<Spesa> spese = new List<Spesa>();

                while (reader.Read())
                {
                    var id =(int)reader["IdSpesa"];
                    var data = (DateTime)reader["Data"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var approvato = (bool)reader["Approvato"];
                    var importo = (decimal)reader["Importo"];
                    Spesa s = new Spesa();
                    s.Id = id;
                    s.Data = data;
                    s.Descrizione = descrizione;
                    s.Approvato = approvato;
                    s.Importo = importo;
                    s.Utente = utente;
                    spese.Add(s);
                }
                connection.Close();

                return spese;
            }
        }

        public static List<Categoria> VisualizzaCategorie()
        {
            using (SqlConnection connection = new SqlConnection(connectionStringSQL))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Categorie";

                SqlDataReader reader = command.ExecuteReader();

                List<Categoria> categorie = new List<Categoria>();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var nome = (string)reader["Categoria"];
                    Categoria c = new Categoria();
                    c.Id = id;
                    c.Nome = nome;

                    categorie.Add(c);
                }
                connection.Close();

                return categorie;
            }
        }

        public static List<Spesa> VisualizzaSpesePerCategoria(int idCategoria)
        {
            using (SqlConnection connection = new SqlConnection(connectionStringSQL))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Spese where IdCategoria=@idCategoria";
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                SqlDataReader reader = command.ExecuteReader();

                List<Spesa> spese = new List<Spesa>();

                while (reader.Read())
                {
                    var data = (DateTime)reader["Data"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var approvato = (bool)reader["Approvato"];
                    var importo = (decimal)reader["Importo"];
                    Spesa s = new Spesa();
                    s.Data = data;
                    s.Descrizione = descrizione;
                    s.Approvato = approvato;
                    s.Importo = importo;
                    s.Utente = utente;
                    spese.Add(s);
                }
                connection.Close();

                return spese;
            }
        }

        internal static List<Spesa> VisualizzaSpeseUtente(string? nomeUtente)
        {
            using (SqlConnection connection = new SqlConnection(connectionStringSQL))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Spese where Utente=@nomeUtente";
                command.Parameters.AddWithValue("@nomeUtente", nomeUtente);
                SqlDataReader reader = command.ExecuteReader();

                List<Spesa> spese = new List<Spesa>();

                while (reader.Read())
                {
                    var data = (DateTime)reader["Data"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var approvato = (bool)reader["Approvato"];
                    var importo = (decimal)reader["Importo"];
                    Spesa s = new Spesa();
                    s.Data = data;
                    s.Descrizione = descrizione;
                    s.Approvato = approvato;
                    s.Importo = importo;
                    s.Utente = utente;
                    spese.Add(s);
                }
                connection.Close();

                return spese;
            }
        }

        internal static bool ApprovaSpesa(int idSpesa)
        {
            bool aggiornato = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringSQL))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update Spese set Approvato='True' where IdSpesa=@idSpesa";
                    command.Parameters.AddWithValue("@idSpesa", idSpesa);

                    int rigaAggiornata = command.ExecuteNonQuery();
                    if (rigaAggiornata == 1)
                    {
                        connection.Close();
                        return aggiornato=true;

                    }
                    else
                    {
                        connection.Close();
                        return aggiornato;

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return aggiornato;
            }
        }

        internal static List<Spesa> VisualizzaSpese()
        {
            using (SqlConnection connection = new SqlConnection(connectionStringSQL))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Spese ";

                SqlDataReader reader = command.ExecuteReader();

                List<Spesa> spese = new List<Spesa>();

                while (reader.Read())
                {
                    var idSpesa = (int)reader["IdSpesa"];
                    var data = (DateTime)reader["Data"];
                    var descrizione = (string)reader["Descrizione"];
                    var utente = (string)reader["Utente"];
                    var approvato = (bool)reader["Approvato"];
                    var importo = (decimal)reader["Importo"];
                    Spesa s = new Spesa();
                    s.Id=idSpesa;
                    s.Data = data;
                    s.Descrizione = descrizione;
                    s.Approvato = approvato;
                    s.Importo = importo;
                    s.Utente = utente;
                    spese.Add(s);
                }
                connection.Close();

                return spese;
            }
        }

        internal static bool AggiungiSpesa(Spesa nuovaSpesa)
        {
            bool aggiunto = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStringSQL))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into Spese values(@data, @descrizione,@ut, @importo,@approv, @idCat )";
                    command.Parameters.AddWithValue("@ut", nuovaSpesa.Utente);
                    command.Parameters.AddWithValue("@descrizione", nuovaSpesa.Descrizione);
                    command.Parameters.AddWithValue("@data", nuovaSpesa.Data); //data non funziona
                    command.Parameters.AddWithValue("@importo", nuovaSpesa.Importo);
                    command.Parameters.AddWithValue("@idCat", nuovaSpesa.CategoriaId);
                    command.Parameters.AddWithValue("@approv", nuovaSpesa.Approvato);

                    int numRighe = command.ExecuteNonQuery();
                    if (numRighe == 1)
                    {
                        connection.Close();
                        return aggiunto=true;
                    }
                    connection.Close();
                    return aggiunto;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return aggiunto;
            }
        }
    }
}

