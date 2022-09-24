using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class ColumnHeadersTests : ClientBase<Startup>
{
    public ColumnHeadersTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void CanBeSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.TableWithHead));
        var components = response.QuerySelectorAll(".govuk-table thead tr th");
        var texts = components.Select(e => e.TextContent.Trim()).ToArray();

        Assert.Equal(new[] {"Month you apply", "Rate for bicycles", "Rate for vehicles"}, texts);
    }

    [Fact]
    public async void HaveHtmlEscapedWhenPassedAsText()
    {
        var response = await Navigate("Table" ,nameof(TableController.HtmlAsText));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.Equal("Foo &lt;script&gt;hacking.do(1337)&lt;/script&gt;", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void AllowHtmlWhenPassedAsHtml()
    {
        var response = await Navigate("Table" ,nameof(TableController.Html));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.Equal("Foo <span>bar</span>", component!.InnerHtml.Trim());
    }

    [Fact]
    public async void CanHaveAFormatSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.TableWithHead));
        var component = response.QuerySelector(".govuk-table thead tr th:last-child");

        Assert.Contains("govuk-table__header--numeric", component!.ClassList);
    }

    [Fact]
    public async void CanHaveAdditionalClasses()
    {
        var response = await Navigate("Table" ,nameof(TableController.HeadWithClasses));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.Contains("my-custom-class", component!.ClassList);
    }

    [Fact]
    public async void CanHaveRowspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.HeadWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.IsAssignableFrom<IHtmlTableHeaderCellElement>(component);
        Assert.Equal(2, ((IHtmlTableHeaderCellElement) component!).RowSpan);
    }

    [Fact]
    public async void CanHaveColspanSpecified()
    {
        var response = await Navigate("Table" ,nameof(TableController.HeadWithRowspanAndColspan));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.IsAssignableFrom<IHtmlTableHeaderCellElement>(component);
        Assert.Equal(2, ((IHtmlTableHeaderCellElement) component!).ColumnSpan);
    }

    [Fact]
    public async void CanHaveAdditionalAttributes()
    {
        var response = await Navigate("Table" ,nameof(TableController.HeadWithAttributes));
        var component = response.QuerySelector(".govuk-table thead tr th");

        Assert.Equal("buzz", component!.GetAttribute("data-fizz"));
    }
}
