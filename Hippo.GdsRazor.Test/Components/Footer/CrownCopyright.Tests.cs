using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class CrownCopyrightTests : ClientBase<Startup>
{
    public CrownCopyrightTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void IsVisible()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.Default));
        var component = response.QuerySelector(".govuk-footer__copyright-logo");

        Assert.Equal("© Crown copyright", component!.TextContent.Trim());
    }

    [Fact]
    public async void CanBeCustomisedWithTextParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithCustomTextContentLicenceAndCopyrightNotice));
        var component = response.QuerySelector(".govuk-footer__copyright-logo");

        Assert.Equal("© Hawlfraint y Goron", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void CanBeCustomisedWithHtmlParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithCustomHtmlContentLicenceAndCopyrightNotice));
        var component = response.QuerySelector(".govuk-footer__copyright-logo");

        Assert.Equal("<span>Hawlfraint y Goron</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void EscapesHtmlInTheTextParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithHtmlPassedAsTextContent));
        var component = response.QuerySelector(".govuk-footer__copyright-logo");

        Assert.Equal("&lt;span&gt;Hawlfraint y Goron&lt;/span&gt;", component!.InnerHtml.Trim());
    }
}
