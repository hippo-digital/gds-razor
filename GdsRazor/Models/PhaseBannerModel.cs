using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the phase banner component to show users your service is still being worked on.
/// </summary>
public class PhaseBannerModel : GdsWithContent
{
    public TagModel? Tag { get; set; }

    public PhaseBannerModel()
    {
    }

    public PhaseBannerModel(GdsContent content) : base(content)
    {
    }

    public static implicit operator PhaseBannerModel(string s) => new(s);
}
