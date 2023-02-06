using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace RetailSolutions.Assessment.HR.Data;

/* This is used if database provider does't define
 * IHRDbSchemaMigrator implementation.
 */
public class NullHRDbSchemaMigrator : IHRDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
