using Microsoft.AspNetCore.Html;

namespace Hippo.GdsRazor.Models.Content;

public class GdsPlain : GdsContent
{
    public static GdsPlain Empty = "";
    public string Text { get; set; }

    public GdsPlain(string text)
    {
        Text = text;
    }

    public static implicit operator GdsPlain(string s) => new (s);
    public override GdsContent WrapIfText(Func<string, Func<object?, IHtmlContent>> html) => new GdsHtml(html(Text));
}