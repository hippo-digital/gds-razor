using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Follow the validation pattern and show an error message when there is a validation error.
/// In the error message explain what went wrong and how to fix it.
/// </summary>
public class ErrorMessageModel : GdsWithContent
{
    /// <summary>
    /// A visually hidden prefix used before the error message.
    /// </summary>
    public string? VisuallyHiddenText { get; set; }

    public ErrorMessageModel()
    {
    }

    public ErrorMessageModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator ErrorMessageModel(string s) => new(s);
}
