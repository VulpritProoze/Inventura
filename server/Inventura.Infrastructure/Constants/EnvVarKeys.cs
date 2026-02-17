namespace Inventura.Infrastructure.Constants;

/// <summary>
/// Contains keys of environment variables or secrets currently used. This class exists to prevent
/// hardcoding keys that may need to be declared e.g. when trying to check if the value of a secret
/// which can be null
/// </summary>
public static class EnvVarKeys
{
    /// <summary>
    /// Database connection
    /// </summary>
    public const string ConnectionString = "DefaultConnection";
}
