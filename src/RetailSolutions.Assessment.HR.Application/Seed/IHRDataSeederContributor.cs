using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailSolutions.Assessment.HR.Seed
{
    public interface IHRDataSeederContributor
    {
        Task SeedAsync();
    }
}
