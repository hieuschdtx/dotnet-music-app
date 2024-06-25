using System.Data;

namespace Music_app.Domain.Commons;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}