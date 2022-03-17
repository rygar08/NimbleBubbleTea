using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Nm.Data;

/* This is used if database provider does't define
 * INmDbSchemaMigrator implementation.
 */
public class NullNmDbSchemaMigrator : INmDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
