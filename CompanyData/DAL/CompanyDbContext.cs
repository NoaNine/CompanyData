using Microsoft.Data.SqlClient;

namespace CompanyData.DAL;

public class CompanyDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public CompanyDbContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = _configuration.GetConnectionString("CompanyDB");
    }

    public SqlConnection CreateConnection()
        => new SqlConnection(_connectionString);

}
