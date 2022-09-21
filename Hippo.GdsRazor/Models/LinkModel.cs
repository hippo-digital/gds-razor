using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

public class LinkModel : GdsWithHref
{
    /// <summary>
    /// A visually hidden prefix used before the error message.
    /// </summary>
    public string? VisuallyHiddenText { get; set; }

    public LinkModel()
    {
    }

    public LinkModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator LinkModel(HTML h) => new(h);
    public static implicit operator LinkModel(GdsContent c) => new(c);
    public static implicit operator LinkModel(string s) => new(s);
    public static implicit operator LinkModel((string, string) t) => new(t.Item2) { Href = t.Item1 };
}
