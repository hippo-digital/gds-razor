using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class HintModel : GdsWithContent
{
    public static implicit operator HintModel(string s) => new() { Content = s };
}
