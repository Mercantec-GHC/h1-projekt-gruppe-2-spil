using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
namespace Domain_Models.DataBase;

public static class DataBaseConnection
{






    public static void DataBaseConnect(string sqlCommand)
    {
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

            string _connection = dbConnectionString;

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
            }

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
