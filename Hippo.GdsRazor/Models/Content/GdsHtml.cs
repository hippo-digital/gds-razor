using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Hippo.GdsRazor.Models.Content;

public class GdsHtml : GdsContent
{
    public Func<IHtmlContent> Html { get; }
    public GdsHtml(Func<object?, IHtmlContent> html)
    {
        Html = () => html(null);
    }

    public GdsHtml(IHtmlContent content) : this(_ => content)
    {
    }

    public override GdsContent WrapIfText(Func<string, Func<object?, IHtmlContent>> html) => this;
    public static implicit operator GdsHtml(Func<object?, IHtmlContent> f) => new(f);
    public static implicit operator GdsHtml(HelperResult f) => new(f);
}