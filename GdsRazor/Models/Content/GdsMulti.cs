using Microsoft.AspNetCore.Html;

namespace GdsRazor.Models.Content;

public class GdsMulti : GdsContent
{
    public GdsContent Left { get; set; }
    public GdsContent Right { get; set; }

    public GdsMulti(GdsContent a, GdsContent b)
    {
        Left = a;
        Right = b;
    }

    public override GdsContent WrapIfText(Func<string, Func<object, IHtmlContent>> html) => this;
}
