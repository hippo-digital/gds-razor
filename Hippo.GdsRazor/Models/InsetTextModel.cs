using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

public class InsetTextModel : GdsWithContent
{
    public InsetTextModel()
    {
    }

    public InsetTextModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator InsetTextModel(string s) => new(s);
}
