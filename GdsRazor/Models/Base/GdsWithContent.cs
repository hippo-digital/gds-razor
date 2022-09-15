using GdsRazor.Models.Content;

namespace GdsRazor.Models.Base;

public abstract class GdsWithContent : GdsViewModel
{
    public GdsContent? Content { get; set; }

    public GdsWithContent() : base(null)
    {
    }

    public GdsWithContent(GdsContent content) : this()
    {
        Content = content;
    }
}