using System.Web;

namespace GdsRazor.Models.Base;

public abstract class GdsAttributes
{
    /// <summary>
    /// HTML attributes (for example data attributes) to add to the element
    /// </summary>
    public Dictionary<string, string?>? Attributes { get; set; }

    protected virtual IEnumerable<KeyValuePair<string, string?>> GetAllAttributes() => Attributes ?? Enumerable.Empty<KeyValuePair<string, string?>>();

    protected static IEnumerable<KeyValuePair<string, string?>> MaybePrepend(IEnumerable<KeyValuePair<string, string?>> enumerable, params KeyValuePair<string, string?>[] toAdd) =>
        toAdd.Aggregate(enumerable, (acc, next) => next.Value == null ? acc : acc.Prepend(next));

    public string ExpandAttributes() => string.Join(" ", GetAllAttributes().Select(x => $"{x.Key}=\"{HttpUtility.HtmlAttributeEncode(x.Value)}\""));
}
