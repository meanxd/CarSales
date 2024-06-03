namespace CarSales.Common.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "Database";
    public const string MainConnectionStringName = "npgsql";

    public string ConnectionString { get; set; } = null!;

    public const string HostEnvVarName = "PGHOST";
    public const string PortEnvVarName = "PGPORT";
    public const string DatabaseEnvVarName = "PGDATABASE";
    public const string UserEnvVarName = "PGUSER";
    public const string PasswordEnvVarName = "PGPASSWORD";

    public int KeepAlive { get; set; } = 60;

    public string KeepAliveConnectionString { get; set; } = null!;
}
