using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class NotificationBannerModel : GdsWithContent
{
    public GdsContent? Title { get; set; }
    public int? TitleHeadingLevel { get; set; }
    public string? Type { get; set; }
    public string? Role { get; set; }
    public string? TitleId { get; set; }
    public bool DisableAutoFocus { get; set; }

    public NotificationBannerModel()
    {
    }

    public NotificationBannerModel(GdsContent content) : base(content)
    {
    }
}
