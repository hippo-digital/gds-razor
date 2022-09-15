using Microsoft.AspNetCore.Html;

namespace GdsRazor.Models.Content
{
    public abstract class GdsContent
    {
        public abstract GdsContent WrapIfText(Func<string, Func<object?, IHtmlContent>> html);

        public static implicit operator GdsContent(string s) => (GdsPlain) s;
        public static implicit operator GdsContent(HTML f) => new GdsHtml(o => f(o));
        public static implicit operator GdsContent(Task<IHtmlContent> t) => new GdsHtml(t.Result);
        public static GdsContent operator +(GdsContent a, GdsContent b) => new GdsMulti(a, b);
        public static GdsContent operator +(GdsContent a, IHtmlContent b) => new GdsMulti(a, new GdsHtml(b));
    }
}

namespace GdsRazor.Models
{
    // Helper to convert from lambdas to GdsContent types
    // ie Content = (HTML) (@<text>My html here <a href="#">Link</a></text>)
    // because this code is actually:
    // Content = (HTML) (item => Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(writer) => { ... }))
    public delegate IHtmlContent HTML(object? o);
}