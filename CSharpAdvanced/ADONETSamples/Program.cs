using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ADONETSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

        } 

        public void SqlDataAdapterSample()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieDbContext-273a27f2-bf77-4cdb-b0db-b8226c4889cd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connectionString);


            #region Tradionelle Verwendung von SqlConnection via try/catch/finally
            try
            {
                con.Open(); //Wenn ConnnectionString falsch wäre oder User - Rechte nicht ausreichend sind, erhalten wir hier eine Exception 

                //Beispiel 1
                SqlCommand cmd = con.CreateCommand();  //SqlCommand Factory Methode - Variante

                //Beispiel 2 (ältere Variante) 
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Movie", con); //andere Variante der Initialisierung 


                #region Abrufen von Daten via SqlDataAdapter 
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd1);
                DataSet dataSet = new(); //Kann multiple DataTables beinhalten
                DataTable dataTable = new();

                sqlDataAdapter.Fill(dataTable);
                #endregion

                #region Zugriff auf DataTable
                Console.WriteLine(dataTable.Rows.Count);
                Console.WriteLine(dataTable.Columns.Count);

                //auslesen eines Datensatzes aus DataTable
                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    Console.WriteLine("Titel des ersten Films: " + dataRow["Title"]);
                }


                //auslesen aller Datensätze
                foreach (DataRow currentRow in dataTable.Rows)
                {
                    Console.WriteLine("Filmtitel: " + currentRow["Title"]);
                }

                #endregion
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
                con.Dispose();
            }

            #endregion

            #region Alternative Möglichkeiten SqlConnection zu verwenden
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {

            }//con1.Dispose wird hier aufgerufen 

            //Methoden Scope Variante
            using SqlConnection con2 = new SqlConnection(connectionString);
            #endregion





        }//con2.Dispose() ;

        public void TransactionSample()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieDbContext-273a27f2-bf77-4cdb-b0db-b8226c4889cd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlTransaction sqlTransaction = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                sqlTransaction = conn.BeginTransaction(); //Ab hier beginnt der Transaction - Scope 
               
                SqlCommand cmd = new SqlCommand("Insert Into ..... ");
                SqlCommand cmd1 = new SqlCommand("Insert Into ..... ");

                try
                {
                    cmd.ExecuteNonQuery(); //Sende SQL Query an Sql Server 
                    cmd1.ExecuteNonQuery();

                    sqlTransaction.Commit();
                }
                catch (Exception)
                {
                    sqlTransaction.Rollback();
                }
                finally
                {
                    
                    conn.Close();
                }

            }//con.Dispose 
        }



        public void SqlCommandParameterSample(int customerId, string demoXml)
        {
            // Update the demographics for a store, which is stored
            // in an xml column.
            string commandText = "UPDATE Sales.Store SET Demographics = @demographics " + "WHERE CustomerID = @ID;";

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MovieDbContext-273a27f2-bf77-4cdb-b0db-b8226c4889cd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = customerId;


                // Use AddWithValue to assign Demographics.
                // SQL Server will implicitly convert strings into XML.
                command.Parameters.AddWithValue("@demographics", demoXml);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();

                    int rowsAffected1 = command.ExecuteNonQuery();

                    
                }
                catch (Exception ex)
                {

                }
            }
        }


        public void SQLDataReader_GetSchemaInfo(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories;", connection);
                connection.Open();

                #region Auslesen von Schema Daten
                //SqlDataReader wird aus dem SQLCommand.ExecuteReader instanziiert 
                SqlDataReader reader = command.ExecuteReader();



                DataTable schemaTable = reader.GetSchemaTable();

                foreach (DataRow row in schemaTable.Rows)
                {
                    foreach (DataColumn column in schemaTable.Columns)
                    {
                        Console.WriteLine(String.Format("{0} = {1}",
                           column.ColumnName, row[column]));
                    }
                }
                #endregion
            }
        }

        public void SqlDataReader_ReadData()
        {
            string connectionString = "...";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //
                // Create new SqlCommand object.
                //
                using (SqlCommand command = new SqlCommand("SELECT * FROM Dogs1", connection))
                {
                    //
                    // Invoke ExecuteReader method.
                    //
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int weight = reader.GetInt32(0);    // Weight int
                        string name = reader.GetString(1);  // Name string
                        string breed = reader.GetString(2); // Breed string
                                                            //
                                                            // Write the values read from the database to the screen.
                                                            //
                        Console.WriteLine("Weight = {0}, Name = {1}, Breed = {2}",
                            weight, name, breed);
                    }
                }
            }
        }
    }
}
