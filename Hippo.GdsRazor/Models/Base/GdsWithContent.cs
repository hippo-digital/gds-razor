using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models.Base;

public abstract class GdsWithContent : GdsViewModel
{
    /// <summary>
    /// Content of the container
    /// </summary>
    public GdsContent? Content { get; set; }

    public GdsWithContent() : base(null)
    {
    }

    public GdsWithContent(GdsContent content) : this()
    {
        Content = content;
    }
}