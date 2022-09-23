using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class ServiceTests : ClientBase<Startup>
{
    public ServiceTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersServiceName()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithServiceName));
        var component = response.QuerySelector(".govuk-header .govuk-header__service-name");

        Assert.Equal("Service Name", component!.TextContent.Trim());
    }

    [Fact]
    public async void WrapsTheServiceNameWithALinkWhenAUrlIsProvided()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithServiceName));
        var component = response.QuerySelector(".govuk-header .govuk-header__service-name");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
        Assert.Equal("/components/header", component!.Attributes["href"]?.Value);
    }

    [Fact]
    public async void DoesNotUseALinkWhenNoServiceUrlIsProvided()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithServiceNameButNoServiceUrl));
        var component = response.QuerySelector(".govuk-header .govuk-header__service-name");

        Assert.IsAssignableFrom<IHtmlSpanElement>(component);
        Assert.Null(component!.Attributes["href"]?.Value);
    }
}
