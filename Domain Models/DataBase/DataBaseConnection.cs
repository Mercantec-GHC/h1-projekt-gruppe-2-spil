using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
namespace Domain_Models.DataBase;

public static class DataBaseConnection
{
    public static string ConnectionString { get; internal set; }


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
