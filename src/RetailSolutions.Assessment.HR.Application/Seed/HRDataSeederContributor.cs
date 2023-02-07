using RetailSolutions.Assessment.HR.Consts;
using RetailSolutions.Assessment.HR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.Uow;

namespace RetailSolutions.Assessment.HR.Seed
{
    public class HRDataSeederContributor : IHRDataSeederContributor, ITransientDependency
    {
        private readonly IRepository<Shift, Guid> _shiftRepository;
        private readonly IIdentityRoleAppService _identityRoleAppService;
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly IRepository<TimeLog, Guid> _timeLogRepository;
        public HRDataSeederContributor(IRepository<Shift, Guid> shiftRepository,
            IIdentityUserAppService identityUserAppService,
            IIdentityRoleAppService identityRoleAppService,
            IRepository<TimeLog, Guid> timeLogRepository)
        {
            _shiftRepository = shiftRepository;
            _identityUserAppService = identityUserAppService;
            _identityRoleAppService = identityRoleAppService;
            _timeLogRepository = timeLogRepository;
        }

        [UnitOfWork]
        public async Task SeedAsync()
        {
            Shift shift = new Shift();
            IdentityUserDto emp1 = new IdentityUserDto();
            IdentityUserDto emp2 = new IdentityUserDto();
            IdentityUserDto emp3 = new IdentityUserDto();
            IdentityUserDto manager = new IdentityUserDto();
            bool isFreshData = false;
            if (await _shiftRepository.GetCountAsync() == 0)
            {
                shift = await _shiftRepository.InsertAsync(new Shift()
                {
                    FromTime = "00:00",
                    ToTime = "08:00",
                    Name = "Night Shift",
                    ShiftType = Enums.eShiftType.NightShift
                }, autoSave: true);
            }

            var existingRoles = await _identityRoleAppService.GetAllListAsync();

            if (!existingRoles.Items.Any(x => x.Name == RoleConsts.Employee))
            {
                await _identityRoleAppService.CreateAsync(new IdentityRoleCreateDto()
                {
                    Name = RoleConsts.Employee,
                    IsPublic = true
                });
            }

            if (!existingRoles.Items.Any(x => x.Name == RoleConsts.Manager))
            {
                await _identityRoleAppService.CreateAsync(new IdentityRoleCreateDto()
                {
                    Name = RoleConsts.Manager,
                    IsPublic = true
                });
            }

            var existingUsers = await _identityUserAppService.GetListAsync(new GetIdentityUsersInput() { MaxResultCount = 50, SkipCount = 0, Filter = "", Sorting = "" });
            if (!existingUsers.Items.Any())
            {
                emp1 = await _identityUserAppService.CreateAsync(new IdentityUserCreateDto()
                {
                    UserName = "emp1@retailsolutions.ie",
                    Password = "P@ssw0rdL0g",
                    Email = "emp1@retailsolutions.ie",
                    IsActive = true,
                    Name = "Amr Hassan",
                    PhoneNumber = "+201000874944",
                    RoleNames = new[] { RoleConsts.Employee }
                });

                emp2 = await _identityUserAppService.CreateAsync(new IdentityUserCreateDto()
                {
                    UserName = "emp2@retailsolutions.ie",
                    Password = "P@ssw0rdL0g",
                    Email = "emp2@retailsolutions.ie",
                    IsActive = true,
                    Name = "Sayed Elwan",
                    PhoneNumber = "+201000874945",
                    RoleNames = new[] { RoleConsts.Employee }
                });

                emp3 = await _identityUserAppService.CreateAsync(new IdentityUserCreateDto()
                {
                    UserName = "emp3@retailsolutions.ie",
                    Password = "P@ssw0rdL0g",
                    Email = "emp3@retailsolutions.ie",
                    IsActive = true,
                    Name = "Mourad Mounir",
                    PhoneNumber = "+201000874946",
                    RoleNames = new[] { RoleConsts.Employee }
                });

                manager = await _identityUserAppService.CreateAsync(new IdentityUserCreateDto()
                {
                    UserName = "manger@retailsolutions.ie",
                    Password = "P@ssw0rdL0g",
                    Email = "manger@retailsolutions.ie",
                    IsActive = true,
                    Name = "Said Foad",
                    PhoneNumber = "+201000874948",
                    RoleNames = new[] { RoleConsts.Manager }
                });
                isFreshData = true;
            }

            if (isFreshData)
            {
                var firstRecordDate = DateTime.Now.AddDays(-10).ClearTime();

                await _timeLogRepository.InsertManyAsync(new List<TimeLog>()
                {
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddHours(8), ToTime = firstRecordDate.AddHours(16)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddHours(1), ToTime = firstRecordDate.AddHours(3)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(1).AddHours(9), ToTime = firstRecordDate.AddDays(1).AddHours(17)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(2).AddHours(9), ToTime = firstRecordDate.AddDays(2).AddHours(16)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(3).AddHours(9), ToTime = firstRecordDate.AddDays(3).AddHours(17)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(4).AddHours(9), ToTime = firstRecordDate.AddDays(4).AddHours(15)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(5).AddHours(9), ToTime = firstRecordDate.AddDays(5).AddHours(15)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(6).AddHours(9), ToTime = firstRecordDate.AddDays(6).AddHours(17)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(7).AddHours(9), ToTime = firstRecordDate.AddDays(7).AddHours(16)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(8).AddHours(9), ToTime = firstRecordDate.AddDays(8).AddHours(17)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(9).AddHours(9), ToTime = firstRecordDate.AddDays(9).AddHours(15)},
                    new TimeLog(){CreatorId = emp1.Id, FromTime = firstRecordDate.AddDays(10).AddHours(9), ToTime = firstRecordDate.AddDays(10).AddHours(15)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddHours(9), ToTime = firstRecordDate.AddHours(16)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddHours(1), ToTime = firstRecordDate.AddHours(5)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(1).AddHours(9), ToTime = firstRecordDate.AddDays(1).AddHours(17)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(2).AddHours(9), ToTime = firstRecordDate.AddDays(2).AddHours(16)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(3).AddHours(9), ToTime = firstRecordDate.AddDays(3).AddHours(17)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(4).AddHours(9), ToTime = firstRecordDate.AddDays(4).AddHours(18)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(5).AddHours(9), ToTime = firstRecordDate.AddDays(5).AddHours(15)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(6).AddHours(9), ToTime = firstRecordDate.AddDays(6).AddHours(14)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(7).AddHours(9), ToTime = firstRecordDate.AddDays(7).AddHours(16)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(8).AddHours(9), ToTime = firstRecordDate.AddDays(8).AddHours(17)},
                    new TimeLog(){CreatorId = emp2.Id, FromTime = firstRecordDate.AddDays(10).AddHours(9), ToTime = firstRecordDate.AddDays(10).AddHours(15)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddHours(9), ToTime = firstRecordDate.AddHours(16)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddHours(1), ToTime = firstRecordDate.AddHours(4)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(1).AddHours(9), ToTime = firstRecordDate.AddDays(1).AddHours(14)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(2).AddHours(9), ToTime = firstRecordDate.AddDays(2).AddHours(15)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(3).AddHours(9), ToTime = firstRecordDate.AddDays(3).AddHours(14)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(4).AddHours(9), ToTime = firstRecordDate.AddDays(4).AddHours(15)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(5).AddHours(9), ToTime = firstRecordDate.AddDays(5).AddHours(16)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddHours(2), ToTime = firstRecordDate.AddHours(3)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(7).AddHours(9), ToTime = firstRecordDate.AddDays(7).AddHours(13)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(8).AddHours(9), ToTime = firstRecordDate.AddDays(8).AddHours(18)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(9).AddHours(9), ToTime = firstRecordDate.AddDays(9).AddHours(12)},
                    new TimeLog(){CreatorId = emp3.Id, FromTime = firstRecordDate.AddDays(10).AddHours(9), ToTime = firstRecordDate.AddDays(10).AddHours(15)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddHours(9), ToTime = firstRecordDate.AddHours(16)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddHours(1), ToTime = firstRecordDate.AddHours(4)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(1).AddHours(9), ToTime = firstRecordDate.AddDays(1).AddHours(14)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(2).AddHours(9), ToTime = firstRecordDate.AddDays(2).AddHours(15)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(3).AddHours(9), ToTime = firstRecordDate.AddDays(3).AddHours(14)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(4).AddHours(9), ToTime = firstRecordDate.AddDays(4).AddHours(15)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(5).AddHours(9), ToTime = firstRecordDate.AddDays(5).AddHours(16)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddHours(2), ToTime = firstRecordDate.AddHours(3)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(7).AddHours(9), ToTime = firstRecordDate.AddDays(7).AddHours(13)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(8).AddHours(9), ToTime = firstRecordDate.AddDays(8).AddHours(18)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(9).AddHours(9), ToTime = firstRecordDate.AddDays(9).AddHours(12)},
                    new TimeLog(){CreatorId = manager.Id, FromTime = firstRecordDate.AddDays(10).AddHours(9), ToTime = firstRecordDate.AddDays(10).AddHours(15)},

                },
                autoSave: true);
            }

        }
    }
}
