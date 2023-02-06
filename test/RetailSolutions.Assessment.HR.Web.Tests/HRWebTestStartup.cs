using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace RetailSolutions.Assessment.HR;

public class HRWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<HRWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
