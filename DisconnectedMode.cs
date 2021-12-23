using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    public static class DisconnectedMode
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void FillDataSet()
        {
            DataSet gestioneSpeseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al db");

                var gestioneSpeseAdapter = InizializzaAdapter(conn);

                gestioneSpeseAdapter.Fill(gestioneSpeseDS, "Spese");

                conn.Close();
                Console.WriteLine("Connessione chiusa");

                //da qui lavoro in modalità disconnessa-> sono offline

                foreach (DataTable table in gestioneSpeseDS.Tables)
                {
                    Console.WriteLine($"{table.TableName} - {table.Rows.Count}");
                }

                Console.WriteLine("Come è fatta la tabella Spese del mio dataset");
                foreach (DataColumn colonna in gestioneSpeseDS.Tables["Spese"].Columns)
                {
                    Console.WriteLine($"{colonna.ColumnName} - {colonna.DataType}");
                }

                

                //Console.WriteLine("----------------Spese---------------");
                //foreach (DataRow item in gestioneSpeseDS.Tables["Spese"].Rows)
                //{
                //    Console.WriteLine($"{item["Id"]} - {item["Utente"]} - {item["Descrizione"]}");
                //}

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }



        private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
        {
            SqlDataAdapter gestioneSpeseAdapter = new SqlDataAdapter();

            //Fill
            gestioneSpeseAdapter.SelectCommand = new SqlCommand("Select * from Spese", conn);
            gestioneSpeseAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //INSERT
            //zioAdapter.InsertCommand = new SqlCommand("Insert into Ingrediente values (@nome, @descr, @udm)", conn);
            //zioAdapter.InsertCommand.Parameters.AddWithValue("@nome", "Nome");
            //zioAdapter.InsertCommand.Parameters.AddWithValue("@descr", "Descrizione");
            //zioAdapter.InsertCommand.Parameters.AddWithValue("@udm", "UnitaDiMisura");
            //gestioneSpeseAdapter.InsertCommand = GeneraInsertCommand(conn);


            //UPDATE
            gestioneSpeseAdapter.UpdateCommand = GeneraUpdateCommand(conn);

            //DELETE
            gestioneSpeseAdapter.DeleteCommand = GeneraDeleteCommand(conn);

            return gestioneSpeseAdapter;
        }





        private static SqlCommand GeneraDeleteCommand(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from Spese where IdSpesa=@id";

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "IdSpesa"));

            return cmd;
        }
        private static SqlCommand GeneraUpdateCommand(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Spese set Data=@data, Descrizione=@descr, Utente=@ut, Importo=@imp, Approvato=@appr, IdCategoria=@idCat where IdSpesa=@id";

            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "IdSpesa"));
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.NVarChar, 50, "Data"));
            cmd.Parameters.Add(new SqlParameter("@descr", SqlDbType.NVarChar, 50, "Descrizione"));
            cmd.Parameters.Add(new SqlParameter("@ut", SqlDbType.NVarChar, 10, "Utente"));
            cmd.Parameters.Add(new SqlParameter("@imp", SqlDbType.Decimal, 5, "Importo"));
            cmd.Parameters.Add(new SqlParameter("@appr", SqlDbType.Bit, 2, "Approvato"));
            cmd.Parameters.Add(new SqlParameter("@idCat", SqlDbType.Int, 0, "IdCategoria"));
            

            return cmd;
        }

        public static void EliminaRiga(int IdRiga)
        {
            DataSet gestioneSpeseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(connectionStringSQL);
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("Connessi al db");
                else
                    Console.WriteLine("NON connessi al db");

                var gestioneSpeseAdapter = InizializzaAdapter(conn);
                gestioneSpeseAdapter.Fill(gestioneSpeseDS, "Spese");


                conn.Close();
                Console.WriteLine("Connessione chiusa");

                DataRow rigaDaEliminare = gestioneSpeseDS.Tables["Spese"].Rows.Find(IdRiga); //by PK
                if (rigaDaEliminare != null)
                {
                    rigaDaEliminare.Delete();
                    Console.WriteLine("Spesa eliminata");
                }
                else
                {
                    Console.WriteLine("Questa spesa non esiste");
                }

                //riconciliazione e quindi vero salvataggio del dato sul db
                gestioneSpeseAdapter.Update(gestioneSpeseDS, "Spese");
                Console.WriteLine("Database Aggiornato");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore generico: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
