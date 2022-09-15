using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class ErrorMessageModel : GdsWithContent
{
    public string? VisuallyHiddenText { get; set; }

    public ErrorMessageModel()
    {
    }

    public ErrorMessageModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator ErrorMessageModel(string s) => new(s);
}
