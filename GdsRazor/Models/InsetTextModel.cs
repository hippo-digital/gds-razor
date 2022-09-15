using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

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
