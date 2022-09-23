using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Accordion;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.Classes));
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Contains("myClass", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.Attributes));
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Equal("value", component!.GetAttribute("data-attribute"));
    }

    [Fact]
    public async void RendersWithSpecifiedHeadingLevel()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.CustomHeadingLevel));
        var componentHeading = response.QuerySelector(".govuk-accordion__section-heading");

        Assert.IsAssignableFrom<IHtmlHeadingElement>(componentHeading);
        Assert.Equal("H3", componentHeading!.TagName);
    }

    [Fact]
    public async void RendersWithHeadingButtonHtml()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.HeadingHtml));
        var componentHeadingButton = response.QuerySelector(".govuk-accordion__section-button");

        Assert.Equal("<span class=\"myClass\">Section A</span>", componentHeadingButton!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersWithSectionExpandedClass()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.WithOneSectionOpen));
        var componentSection = response.QuerySelector(".govuk-accordion__section");

        Assert.Contains("govuk-accordion__section--expanded", componentSection!.ClassList);
    }

    [Fact]
    public async void RendersWithSummary()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.WithAdditionalDescriptions));
        var componentSummary = response.QuerySelector(".govuk-accordion__section-summary");

        Assert.Equal("Additional description", componentSummary!.TextContent.Trim());
    }

    [Fact]
    public async void RendersWithLocalisationDataAttributes()
    {
        var response = await Navigate("Accordion" ,nameof(AccordionController.WithTranslations));
        var component = response.QuerySelector(".govuk-accordion");

        Assert.Equal("Collapse all sections", component!.GetAttribute("data-i18n.hide-all-sections"));
        Assert.Equal("Expand all sections", component.GetAttribute("data-i18n.show-all-sections"));
        Assert.Equal("Collapse <span class=\"govuk-visually-hidden\">this section</span>", component.GetAttribute("data-i18n.hide-section"));
        Assert.Equal("Expand <span class=\"govuk-visually-hidden\">this section</span>", component.GetAttribute("data-i18n.show-section"));
    }
}
