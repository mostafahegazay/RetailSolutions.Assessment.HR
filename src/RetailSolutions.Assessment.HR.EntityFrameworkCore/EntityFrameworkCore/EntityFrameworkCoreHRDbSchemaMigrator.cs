using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetailSolutions.Assessment.HR.Data;
using Volo.Abp.DependencyInjection;

namespace RetailSolutions.Assessment.HR.EntityFrameworkCore;

public class EntityFrameworkCoreHRDbSchemaMigrator
    : IHRDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHRDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HRDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HRDbContext>()
            .Database
            .MigrateAsync();
    }
}
