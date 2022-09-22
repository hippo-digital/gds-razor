using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class ContentLicenceTests : ClientBase<Startup>
{
    public ContentLicenceTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void IsVisible()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.Default));
        var component = response.QuerySelector(".govuk-footer__licence-description");

        Assert.Equal("All content is available under the Open Government Licence v3.0, except where otherwise stated", component!.TextContent.Trim());
    }

    [Fact]
    public async void CanBeCustomisedWithTextParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithCustomTextContentLicenceAndCopyrightNotice));
        var component = response.QuerySelector(".govuk-footer__licence-description");

        Assert.Equal("Mae'r holl gynnwys ar gael dan Drwydded y Llywodraeth Agored v3.0, ac eithrio lle nodir yn wahanol", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void CanBeCustomisedWithHtmlParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithCustomHtmlContentLicenceAndCopyrightNotice));
        var component = response.QuerySelector(".govuk-footer__licence-description");

        const string expected = "Mae'r holl gynnwys ar gael dan <a class=\"govuk-footer__link\" " +
                                "href=\"https://www.nationalarchives.gov.uk/doc/open-government-licence-cymraeg/version/3/\" rel=\"license\">" +
                                "Drwydded y Llywodraeth Agored v3.0</a>, ac eithrio lle nodir yn wahanol";

        Assert.Equal(expected, component!.InnerHtml.Trim());
    }

    [Fact]
    public async void EscapesHtmlInTheTextParameter()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithHtmlPassedAsTextContent));
        var component = response.QuerySelector(".govuk-footer__licence-description");

        const string expected = "Mae'r holl gynnwys ar gael dan &lt;a class=\"govuk-footer__link\" " +
                                "href=\"https://www.nationalarchives.gov.uk/doc/open-government-licence-cymraeg/version/3/\" rel=\"license\"&gt;" +
                                "Drwydded y Llywodraeth Agored v3.0&lt;/a&gt;, ac eithrio lle nodir yn wahanol";

        Assert.Equal(expected, component!.InnerHtml.Trim());
    }
}
