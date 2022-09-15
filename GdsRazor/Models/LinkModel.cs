using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class LinkModel : GdsWithHref
{
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
