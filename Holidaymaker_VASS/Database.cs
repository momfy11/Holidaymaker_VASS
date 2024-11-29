using Npgsql;
namespace app;

public class Database
{
    private readonly string _host = "localhost";
    private readonly string _port = "5432";
    private readonly string _username = "postgres";
    private readonly string _password = "Playa717";
    private readonly string _database = "holidaymaker_database";
    // private readonly string _schema = "public";
    
    private NpgsqlDataSource _connection;

    public NpgsqlDataSource Connection()
    {
        return _connection;
    }
    
    public Database()
    {
        _connection = NpgsqlDataSource.Create($"Host={_host};Port={_port};Username={_username};Password={_password};Database={_database}");

        using var conn = _connection.OpenConnection();
    }
}