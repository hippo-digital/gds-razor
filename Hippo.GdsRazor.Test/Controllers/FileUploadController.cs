using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class FileUploadController : Controller
{
    private static class Examples
    {
        public static readonly FileUploadModel Default = new("file-upload-1", "file-upload-1", "Upload a file");
        public static readonly FileUploadModel Classes = new("file-upload-classes", "file-upload-classes", "Upload a file") {
            Classes = "app-file-upload--custom-modifier"
        };
        public static readonly FileUploadModel WithValue = new("file-upload-4", "file-upload-4", "Upload a photo") {
            Value = "C:\\fakepath\\myphoto.jpg"
        };
        public static readonly FileUploadModel WithDescribedBy = new("file-upload-describedby", "file-upload-describedby", "Upload a file") {
            DescribedBy = "some-id"
        };
        public static readonly FileUploadModel Attributes = new("file-upload-attributes", "file-upload-attributes", "Upload a file") {
            Attributes = new Dictionary<string, string?> {{"accept", ".jpg, .jpeg, .png"}} 
        };
        public static readonly FileUploadModel WithOptionalFormGroupClasses = new("file-upload-1", "file-upload-1", "Upload a file") {
            FormGroupClasses = "extra-class"
        };
        public static readonly FileUploadModel WithHintText = new("file-upload-2", "file-upload-2", "Upload your photo") {
            Hint = "Your photo may be in your Pictures, Photos, Downloads or Desktop folder. Or in an app like iPhoto."
        };
        public static readonly FileUploadModel WithHintAndDescribedBy = new("file-upload-hint-describedby", "file-upload-hint-describedby", "Upload a file") {
            Label = "Upload a file",
            DescribedBy = "some-id",
            Hint = "Your photo may be in your Pictures, Photos, Downloads or Desktop folder. Or in an app like iPhoto."
        };
        public static readonly FileUploadModel Error = new("file-upload-with-error", "file-upload-with-error", "Upload a file") {
            ErrorMessage = "Error message"
        };
        public static readonly FileUploadModel WithErrorAndDescribedBy = new("file-upload-error-describedby", "file-upload-error-describedby", "Upload a file") {
            DescribedBy = "some-id",
            Label = "Upload a file",
            ErrorMessage = "Error message"
        };
        public static readonly FileUploadModel WithErrorMessageAndHint = new("file-upload-3", "file-upload-3", "Upload a file") {
            Hint = "Your photo may be in your Pictures, Photos, Downloads or Desktop folder. Or in an app like iPhoto.",
            ErrorMessage = "Error message goes here"
        };
        public static readonly FileUploadModel WithErrorDescribedByAndHint = new("file-upload-error-describedby-hint", "file-upload-error-describedby-hint", "Upload a file") {
            Label = "Upload a file",
            ErrorMessage = "Error message",
            DescribedBy = "some-id",
            Hint = "hint"
        };
    }

    private const string PartialName = "GdsFileUpload";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult WithValue() => PartialView(PartialName, Examples.WithValue);
    public IActionResult WithDescribedBy() => PartialView(PartialName, Examples.WithDescribedBy);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult WithOptionalFormGroupClasses() => PartialView(PartialName, Examples.WithOptionalFormGroupClasses);
    public IActionResult WithHintText() => PartialView(PartialName, Examples.WithHintText);
    public IActionResult WithHintAndDescribedBy() => PartialView(PartialName, Examples.WithHintAndDescribedBy);
    public IActionResult Error() => PartialView(PartialName, Examples.Error);
    public IActionResult WithErrorAndDescribedBy() => PartialView(PartialName, Examples.WithErrorAndDescribedBy);
    public IActionResult WithErrorMessageAndHint() => PartialView(PartialName, Examples.WithErrorMessageAndHint);
    public IActionResult WithErrorDescribedByAndHint() => PartialView(PartialName, Examples.WithErrorDescribedByAndHint);
    public IActionResult Axe() => View(Examples.Default);
}
