using System.Data.SqlClient;

public class DB
{
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(
            "Server=.;Database=HospitalSystem;Trusted_Connection=True;"
        );
    }
}