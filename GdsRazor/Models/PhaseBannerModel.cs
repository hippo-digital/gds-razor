using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class PhaseBannerModel : GdsWithContent
{
    public TagModel? Tag { get; set; }

    public PhaseBannerModel()
    {
    }

    public PhaseBannerModel(GdsContent content) : base(content)
    {
    }
}
