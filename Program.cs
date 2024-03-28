using System.Data;
using Microsoft.Data.SqlClient;
namespace MySQLConsoleApp
{
    class Prog()
    {
        static void Main(string[] args){
            /*Console.WriteLine("Enter UserName:");
            String username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            String password = Console.ReadLine();
            Console.WriteLine(username + " , " + password);*/
            
            //build connection object
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost"; 
            builder.UserID = "sa";            
            builder.Password = "5uper5trongPW!";     
            builder.InitialCatalog = "NewDB";
            builder.TrustServerCertificate = true;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    
                    //SQL query to be used      
                    String sqlquery ="SELECT * FROM EMployees;";

                    //create datatable in C#
                    DataTable Table = new DataTable("TestTable");
                    using(SqlCommand cmd = new SqlCommand(sqlquery, connection))
                    {
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        connection.Open();
                        dap.Fill(Table);
                        connection.Close();

                    }
                    Console.WriteLine(Table.Rows.Count);
                    //output datatable in console
                    foreach(DataRow dataRow in Table.Rows)
                    {
                        foreach(var item in dataRow.ItemArray)
                        {
                            Console.Write(item + ", ");
                        }
                        Console.WriteLine("\b\b ");
                    }

                    Console.WriteLine("\n=========================================\n");

                    //use reader to output same info
                    using (SqlCommand command = new SqlCommand(sqlquery, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    } 
                    connection.Close();   

                    string script = File.ReadAllText(@"/Users/zacharyroberts/git/my_sql_server/CreateStoredProcedure");                   {
                        
                    }
                    
                    DataTable Table2 = new DataTable("TestTable2");
                    using(SqlCommand cmd = new SqlCommand(script, connection))
                    {
                        SqlDataAdapter dap = new SqlDataAdapter(cmd);
                        connection.Open();
                        dap.Fill(Table2);
                        connection.Close();

                    }
                    Console.WriteLine(Table2.TableName);
                    //output datatable in console
                    foreach(DataRow dataRow in Table2.Rows)
                    {
                        foreach(var item in dataRow.ItemArray)
                        {
                            Console.Write(item + ", ");
                        }
                        Console.WriteLine("\b\b ");
                    }

                                 
                }
        }
    }
}
 