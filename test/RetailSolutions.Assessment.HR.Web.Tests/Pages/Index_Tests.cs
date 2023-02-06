using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace RetailSolutions.Assessment.HR.Pages;

public class Index_Tests : HRWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
