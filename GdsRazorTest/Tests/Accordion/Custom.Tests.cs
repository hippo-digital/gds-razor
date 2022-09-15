using GdsRazorTest.Tests.Internal;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GdsRazorTest.Tests.Accordion;

public class CustomTests : GdsTestBase
{
    public CustomTests(WebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("/Accordion/Classes");
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Contains("myClass", component.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("/Accordion/Attributes");
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Equal("value", component.Attributes["data-attribute"].Value);
    }

    [Fact]
    public async void RendersWithSpecifiedHeadingLevel()
    {
        var response = await Navigate("/Accordion/CustomHeadingLevel");
        var componentHeading = response.QuerySelector(".govuk-accordion__section-heading");

        Assert.Equal("H3", componentHeading.TagName);
    }

    [Fact]
    public async void RendersWithHeadingButtonHtml()
    {
        var response = await Navigate("/Accordion/HeadingHtml");
        var componentHeadingButton = response.QuerySelector(".govuk-accordion__section-button");

        Assert.Equal("<span class=\"myClass\">Section A</span>", componentHeadingButton.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersWithSectionExpandedClass()
    {
        var response = await Navigate("/Accordion/WithOneSectionOpen");
        var componentSection = response.QuerySelector(".govuk-accordion__section");

        Assert.Contains("govuk-accordion__section--expanded", componentSection.ClassList);
    }

    [Fact]
    public async void RendersWithSummary()
    {
        var response = await Navigate("/Accordion/WithAdditionalDescriptions");
        var componentSummary = response.QuerySelector(".govuk-accordion__section-summary");

        Assert.Equal("Additional description", componentSummary.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithLocalisationDataAttributes()
    {
        var response = await Navigate("/Accordion/WithTranslations");
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Equal("Collapse all sections", component.Attributes["data-i18n.hide-all-sections"].Value);
        Assert.Equal("Expand all sections", component.Attributes["data-i18n.show-all-sections"].Value);
        Assert.Equal("Collapse <span class=\"govuk-visually-hidden\">this section</span>", component.Attributes["data-i18n.hide-section"].Value);
        Assert.Equal("Expand <span class=\"govuk-visually-hidden\">this section</span>", component.Attributes["data-i18n.show-section"].Value);
    }
}
