using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Tag;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("Tag");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersTheDefaultExampleWithStrongElementAndText()
    {
        var response = await Navigate("Tag" ,nameof(TagController.Default));
        var component = response.QuerySelector(".govuk-tag");

        Assert.Equal("STRONG", component!.TagName);
        Assert.Equal("alpha", component.TextContent.Trim());
    }

    [Fact]
    public async void RendersClasses()
    {
        var response = await Navigate("Tag" ,nameof(TagController.Inactive));
        var component = response.QuerySelector(".govuk-tag");

        Assert.Contains("govuk-tag--grey", component!.ClassList);
    }
}
