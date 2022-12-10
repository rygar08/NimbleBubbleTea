using System.Threading.Tasks;

namespace Nm.Data;

public interface INmDbSchemaMigrator
{
    Task MigrateAsync();
}
