using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Tag;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersCustomText()
    {
        var response = await Navigate("Tag" ,nameof(TagController.Grey));
        var component = response.QuerySelector(".govuk-tag");

        Assert.Equal("Grey", component!.TextContent.Trim());
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("Tag" ,nameof(TagController.Attributes));
        var component = response.QuerySelector(".govuk-tag");

        Assert.Equal("my-tag", component!.Id);
        Assert.Equal("attribute", component.Attributes["data-test"]?.Value);
    }
}
