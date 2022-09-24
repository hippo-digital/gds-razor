using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.SummaryList;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("SummaryList");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.NoBorder));
        var component = response.QuerySelector(".govuk-summary-list");

        Assert.Contains("govuk-summary-list--no-border", component!.ClassList);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Attributes));
        var component = response.QuerySelector(".govuk-summary-list");

        Assert.Equal("value-1", component!.GetAttribute("data-attribute-1"));
        Assert.Equal("value-2", component.GetAttribute("data-attribute-2"));
    }

    [Fact]
    public async void RendersClassesOnRows()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.RowsWithClasses));
        var component = response.QuerySelector(".govuk-summary-list .govuk-summary-list__row");

        Assert.Contains("app-custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersTextOnKeys()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Default));
        var component = response.QuerySelector(".govuk-summary-list dt.govuk-summary-list__key");

        Assert.Equal("Name", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtmlOnKeys()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.KeyWithHtml));
        var component = response.QuerySelector(".govuk-summary-list dt.govuk-summary-list__key");

        Assert.Equal("<b>Name</b>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClassesOnKeys()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.KeyWithClasses));
        var component = response.QuerySelector(".govuk-summary-list dt.govuk-summary-list__key");

        Assert.Contains("app-custom-class", component!.ClassList);
    }

    [Fact]
    public async void RendersTextOnValues()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.Default));
        var component = response.QuerySelector(".govuk-summary-list dd.govuk-summary-list__value");

        Assert.Equal("Firstname Lastname", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersHtmlOnValues()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.ValueWithHtml));
        var component = response.QuerySelector(".govuk-summary-list dd.govuk-summary-list__value");

        Assert.Equal("<span>email@email.com</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void RendersClassesOnValues()
    {
        var response = await Navigate("SummaryList" ,nameof(SummaryListController.OverridenWidths));
        var component = response.QuerySelector(".govuk-summary-list dd.govuk-summary-list__value");

        Assert.Contains("govuk-!-width-one-quarter", component!.ClassList);
    }
}
