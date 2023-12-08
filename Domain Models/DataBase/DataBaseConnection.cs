using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
namespace Domain_Models.DataBase;

public static class DataBaseConnection
{ 

    public static SqlConnection _connection;

    public static string InsertListing(SqlCommand cmd){
        return cmd.ExecuteNonQuery().ToString();
        
    }
public static void DataBaseConnect(){
    string? dbSource = System.Environment.GetEnvironmentVariable("ASPNETCORE_DATASOURCE");
    string? dbUser = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBUsername");
    string? dbPassword = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBPassword");
    string? dbCatalog = System.Environment.GetEnvironmentVariable("ASPNETCORE_DBName");
    string? dbConnectionString = System.Environment.GetEnvironmentVariable("ASPNETCORE_CONNECTIONSTRING");
try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                /*builder.DataSource = dbSource; 
                builder.UserID = dbUser;            
                builder.Password = dbPassword;     
                builder.InitialCatalog = dbCatalog;*/

                //builder.ConnectionString="Server=tcp:h1-grp2-dbserver.database.windows.net,1433;Initial Catalog=H1-Grp2-Blazor-Eksamen-Database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication='Active Directory Default';";
         
                _connection = new SqlConnection(builder.ConnectionString = dbConnectionString);

                _connection.Open();

                // ------------------
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine(); 
            }
}
