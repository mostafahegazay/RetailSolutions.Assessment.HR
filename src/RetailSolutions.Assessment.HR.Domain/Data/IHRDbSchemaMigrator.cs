using System.Threading.Tasks;

namespace RetailSolutions.Assessment.HR.Data;

public interface IHRDbSchemaMigrator
{
    Task MigrateAsync();
}
