using AngleSharp.Html.Dom;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Button;

public class ImplicitTests : ClientBase<Startup>
{
    public ImplicitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersALinkIfYouPassAnHref()
    {
        var response = await Navigate("/Button/Link");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
    }

    [Fact]
    public async void RendersAButtonIfYouDontPassAnything()
    {
        var response = await Navigate("/Button/NoType");
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(component);
    }
}
