using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.WarningText;

public class HtmlTests : ClientBase<Startup>
{
    public HtmlTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersEscapedHtmlWhenPassedAsText()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.HtmlAsText));
        var component = response.QuerySelector(".govuk-warning-text");

        Assert.Contains("&lt;span&gt;Some custom warning text&lt;/span&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtml()
    {
        var response = await Navigate("WarningText" ,nameof(WarningTextController.Html));
        var component = response.QuerySelector(".govuk-warning-text");

        Assert.Contains("<span>Some custom warning text</span>", component!.InnerHtml.Trim());
    }
}
