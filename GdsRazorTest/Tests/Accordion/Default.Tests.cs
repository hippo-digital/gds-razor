using GdsRazorTest.Tests.Internal;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GdsRazorTest.Tests.Accordion;

public class DefaultTests : GdsTestBase
{
    public DefaultTests(WebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithHeadingButtonText()
    {
        var response = await Navigate("/Accordion/Default");
        var componentHeadingButton = response.QuerySelector(".govuk-accordion__section-button");
        
        Assert.Equal("Section A", componentHeadingButton.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithContentAsTextWrappedInStyledParagraph()
    {
        var response = await Navigate("/Accordion/Default");
        var componentContent  = response.QuerySelector(".govuk-accordion__section-content");
        var expectedDefaultBody = "We need to know your nationality so we can work out which elections you’re entitled to vote in. " +
                                  "If you cannot provide your nationality, you’ll have to send copies of identity documents through the post.";

        Assert.Contains("govuk-body", componentContent.QuerySelector("p").ClassList);
        Assert.Equal(expectedDefaultBody, componentContent.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithContentAsHtml()
    {
        var response = await Navigate("/Accordion/Default");
        var componentContent = response.QuerySelectorAll(".govuk-accordion__section-content").Last();

        Assert.Equal(0, componentContent.QuerySelectorAll("p.govuk-body").Length);
        Assert.Equal("Example item 2", componentContent.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("/Accordion/Default");
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Equal("default-example", component.Id);
    }
}
