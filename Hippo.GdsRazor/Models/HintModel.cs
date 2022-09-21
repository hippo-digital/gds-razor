using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

public class HintModel : GdsWithContent
{
    public HintModel()
    {
    }

    public HintModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator HintModel(string s) => new(s);
}
