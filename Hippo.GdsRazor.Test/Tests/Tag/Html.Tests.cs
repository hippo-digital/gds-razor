using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Tag;

public class HtmlTests : ClientBase<Startup>
{
    public HtmlTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersEscapedHtmlWhenPassedToText()
    {
        var response = await Navigate("/Tag/HtmlAsText");
        var component = response.QuerySelector(".govuk-tag");

        Assert.Equal("&lt;span&gt;alpha&lt;/span&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersAttributes()
    {
        var response = await Navigate("/Tag/Html");
        var component = response.QuerySelector(".govuk-tag");

        Assert.Equal("<span>alpha</span>", component!.InnerHtml.Trim());
    }
}
