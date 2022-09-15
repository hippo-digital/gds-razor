using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class SkipLinkModel : GdsWithHref
{
    public SkipLinkModel()
    {
    }

    public SkipLinkModel(GdsContent content) : base(content)
    {
    }
}
