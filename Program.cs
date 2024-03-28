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
                    
                    connection.Open();       

                    String sqlquery = "SELECT * FROM Employees;";

                    using (SqlCommand command = new SqlCommand(sqlquery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                    }   
                    connection.Close();                
                }
        }
    }
}
 