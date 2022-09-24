using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class RowHeadersTests : ClientBase<Startup>
{
    public RowHeadersTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void WhenFirstCellIsHeaderIsFalseAreNotIncluded()
    {
        var response = await Navigate("Table" ,nameof(TableController.Default));
        var components = response.QuerySelectorAll(".govuk-table tbody tr td");
        var texts = components.Select(e => e.TextContent.Trim()).ToArray();

        Assert.Equal(new[] {"January", "£85", "£95", "February", "£75", "£55", "March", "£165", "£125"}, texts);
    }

    [Fact]
    public async void WhenFirstCellIsHeaderIsTrueAreIncluded()
    {
        var response = await Navigate("Table" ,nameof(TableController.WithFirstCellIsHeaderTrue));
        var components = response.QuerySelectorAll(".govuk-table tbody tr th");
        var texts = components.Select(e => e.TextContent.Trim()).ToArray();

        Assert.Equal(new[] {"January", "February", "March"}, texts);
    }

    [Fact]
    public async void HaveHtmlEscapedWhenPassedAsText()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithHtmlAsText));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.Equal("Foo &lt;script&gt;hacking.do(1337)&lt;/script&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowHtmlWhenPassedAsHtml()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithHtml));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.Equal("Foo <span>bar</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AreAssociatedWithTheirRowsUsingScopeRow()
    {
        var response = await Navigate("Table" ,nameof(TableController.WithFirstCellIsHeaderTrue));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.IsAssignableFrom<IHtmlTableHeaderCellElement>(component);
        Assert.Equal("row", ((IHtmlTableHeaderCellElement) component!).Scope);
    }

    [Fact]
    public async void HaveTheGovukTableHeaderClass()
    {
        var response = await Navigate("Table" ,nameof(TableController.WithFirstCellIsHeaderTrue));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.Contains("govuk-table__header", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAdditionalClasses()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithClasses));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.Contains("my-custom-class", component!.ClassList);
    }

    [Fact]
    public async void CanHaveRowspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.IsAssignableFrom<IHtmlTableHeaderCellElement>(component);
        Assert.Equal(2, ((IHtmlTableHeaderCellElement) component!).RowSpan);
    }

    [Fact]
    public async void CanHaveColspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.IsAssignableFrom<IHtmlTableHeaderCellElement>(component);
        Assert.Equal(2, ((IHtmlTableHeaderCellElement) component!).ColumnSpan);
    }

    [Fact]
    public async void CanHaveAdditionalAttributes()
    {
        var response = await Navigate("Table" ,nameof(TableController.FirstCellIsHeaderWithAttributes));
        var component = response.QuerySelector(".govuk-table tbody tr th");

        Assert.Equal("buzz", component!.GetAttribute("data-fizz"));
    }
}
