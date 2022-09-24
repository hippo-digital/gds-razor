using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class CellsTests : ClientBase<Startup>
{
    public CellsTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void CanBeSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.Default));
        var components = response.QuerySelectorAll(".govuk-table tbody tr");
        var texts = components.Select(e => e.QuerySelectorAll("td").Select(td => td.TextContent.Trim()).ToArray()).ToArray();

        Assert.Equal(new[] {new [] {"January", "£85", "£95"}, new[] {"February", "£75", "£55"}, new[] {"March", "£165", "£125"}}, texts);
    }

    [Fact]
    public async void HaveHtmlEscapedWhenPassedAsText()
    {
        var response = await Navigate("Table" ,nameof(TableController.HtmlAsText));
        var component = response.QuerySelector(".govuk-table td");

        Assert.Equal("Foo &lt;script&gt;hacking.do(1337)&lt;/script&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowHtmlWhenPassedAsHtml()
    {
        var response = await Navigate("Table" ,nameof(TableController.Html));
        var component = response.QuerySelector(".govuk-table td");

        Assert.Equal("Foo <span>bar</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void CanHaveAFormatSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.Default));
        var component = response.QuerySelector(".govuk-table td:last-child");

        Assert.Contains("govuk-table__cell--numeric", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAdditionalClasses()
    {
        var response = await Navigate("Table" ,nameof(TableController.RowsWithClasses));
        var component = response.QuerySelector(".govuk-table td");

        Assert.Contains("my-custom-class", component!.ClassList);
    }

    [Fact]
    public async void CanHaveRowspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.RowsWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table td");

        Assert.IsAssignableFrom<IHtmlTableDataCellElement>(component);
        Assert.Equal(2, ((IHtmlTableDataCellElement) component!).RowSpan);
    }

    [Fact]
    public async void CanHaveColspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.RowsWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table td");

        Assert.IsAssignableFrom<IHtmlTableDataCellElement>(component);
        Assert.Equal(2, ((IHtmlTableDataCellElement) component!).ColumnSpan);
    }

    [Fact]
    public async void CanHaveAdditionalAttributes()
    {
        var response = await Navigate("Table" ,nameof(TableController.RowsWithAttributes));
        var component = response.QuerySelector(".govuk-table td");

        Assert.Equal("buzz", component!.GetAttribute("data-fizz"));
    }
}
