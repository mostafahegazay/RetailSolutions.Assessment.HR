using RetailSolutions.Assessment.HR.Entities;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace RetailSolutions.Assessment.HR;

public class HRTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Shift, Guid> _shiftRepository;
    public HRTestDataSeedContributor(IRepository<Shift, Guid> shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _shiftRepository.GetCountAsync() > 0)
        {
            await _shiftRepository.InsertAsync(new Shift()
            {
                FromTime = "00:00",
                ToTime = "08:00",
                Name = "Night Shift",
                ShiftType = Enums.eShiftType.NightShoft
            }, autoSave: true);
        }
    }
}
