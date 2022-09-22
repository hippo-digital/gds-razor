using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.FileUpload;

public class CustomTests : ClientBase<Startup>
{
    public CustomTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithClasses()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Classes));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.Contains("app-file-upload--custom-modifier", component!.ClassList);
    }

    [Fact]
    public async void RendersWithValue()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithValue));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.IsAssignableFrom<IHtmlInputElement>(component);
        Assert.Equal("C:\\fakepath\\myphoto.jpg", ((IHtmlInputElement) component!).Value);
    }

    [Fact]
    public async void RendersWithAriaDescribedBy()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithDescribedBy));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.Equal("some-id", component!.Attributes[AriaDescribedBy]?.Value);
    }

    [Fact]
    public async void RendersWithAttributes()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.Attributes));
        var component = response.QuerySelector(".govuk-file-upload");

        Assert.Equal(".jpg, .jpeg, .png", component!.Attributes["accept"]?.Value);
    }

    [Fact]
    public async void RendersWithAFormGroupWrapperThatHasExtraClasses()
    {
        var response = await Navigate("FileUpload" ,nameof(FileUploadController.WithOptionalFormGroupClasses));
        var component = response.QuerySelector(".govuk-form-group");

        Assert.Contains("extra-class", component!.ClassList);
    }
}
