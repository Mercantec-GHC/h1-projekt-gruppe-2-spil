using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
namespace BlazorApp.DataBase;

public class DataBaseConnection
{ 
public static void DataBaseConnect(){
    string? dbSource = System.Environment.GetEnvironmentVariable("ASPNETCORE_DATASOURCE");
    string? dbUser = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBUsername");
    string? dbPassword = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBPassword");
    string? dbCatalog = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBName");
try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = dbSource; 
                builder.UserID = dbUser;            
                builder.Password = dbPassword;     
                builder.InitialCatalog = dbCatalog;

                //builder.ConnectionString="Server=tcp:h1-grp2-dbserver.database.windows.net,1433;Initial Catalog=H1-Grp2-Blazor-Eksamen-Database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default';";
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    /*String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }  */                  
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine(); 
            }
}
