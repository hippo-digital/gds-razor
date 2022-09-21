using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Button;

public class ImplicitTests : ClientBase<Startup>
{
    public ImplicitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersALinkIfYouPassAnHref()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.Link));
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlAnchorElement>(component);
    }

    [Fact]
    public async void RendersAButtonIfYouDontPassAnything()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.NoType));
        var component = response.QuerySelector(".govuk-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(component);
    }
}
