using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class DefaultTests : ClientBase<Startup>
{
    public DefaultTests(CustomWebApplicationFactory<Startup> factory, SeleniumBase seleniumBase) : base(factory, seleniumBase.Driver)
    {
    }

    [Fact]
    public void PassesAccessibilityTests()
    {
        var axeResult = AxeResults("FileUpload");

        Assert.Empty(axeResult.Violations);
    }

    [Fact]
    public async void RendersWithId()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Default));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.Equal("file-upload-1", component!.Id);
    }

    [Fact]
    public async void RendersWithName()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Default));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("file-upload-1", ((IHtmlInputElement) component!).Name);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapper()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Default));
        var components = response.QuerySelectorAll(".govuk-form-group");

        Assert.NotEmpty(components);
    }
}
