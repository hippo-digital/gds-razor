using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

public class HintModel : GdsWithContent
{
    public static implicit operator HintModel(string s) => new() { Content = s };
}
