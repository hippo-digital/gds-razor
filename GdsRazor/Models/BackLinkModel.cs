using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class BackLinkModel : GdsWithHref
{
    public BackLinkModel()
    {
        Content = "Back";
    }

    public BackLinkModel(string href) : this()
    {
        Href = href;
    }
}
