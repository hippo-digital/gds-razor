using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class CaptionsTests : ClientBase<Startup>
{
    public CaptionsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void CanHaveCustomText()
    {
        var response = await Navigate("Table" ,nameof(TableController.TableWithHeadAndCaption));
        var component = response.QuerySelector(".govuk-table__caption");

        Assert.Equal("Caption 1: Months and rates", component!.TextContent.Trim());
    }

    [Fact]
    public async void CanHaveAdditionalClasses()
    {
        var response = await Navigate("Table" ,nameof(TableController.TableWithHeadAndCaption));
        var component = response.QuerySelector(".govuk-table__caption");

        Assert.Contains("govuk-heading-m", component!.ClassList);
    }
}
