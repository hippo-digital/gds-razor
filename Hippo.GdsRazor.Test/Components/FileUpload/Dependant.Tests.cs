using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HaveCorrectNestingOrder()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Error));
        var component = response.QuerySelectorAll(".govuk-form-group > .govuk-file-upload");

        Assert.NotEmpty(component);
    }

    [Fact]
    public async void RendersWithLabel()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Default));
        var html = HtmlWithClassName(response, "govuk-label");

        const string expected = "<label class=\"govuk-label \" for=\"file-upload-1\">Upload a file</label>";

        Assert.Equal(expected, html);
    }

    [Fact]
    public async void RendersLabelWithForAttributeReferencingTheFileUploadId()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Default));
        var component = response.QuerySelector(".govuk-label");

        Assert.IsAssignableFrom<IHtmlLabelElement>(component);
        Assert.Equal("file-upload-1", ((IHtmlLabelElement) component!).HtmlFor);
    }
}
