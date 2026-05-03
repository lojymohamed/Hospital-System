using System.Data.SqlClient;

public class DB
{
    public static SqlConnection GetConnection()
    {
        // Added 'TrustServerCertificate=True' to bypass the SSL error
        return new SqlConnection(
            "Server=.;Database=HospitalSystem;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}