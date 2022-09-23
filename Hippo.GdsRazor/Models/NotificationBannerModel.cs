using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Use a notification banner to tell the user about something they need to know about, but that's not directly related to the page content.
/// </summary>
public class NotificationBannerModel : GdsWithContent
{
    /// <summary>
    /// The title text that displays in the notification banner.
    /// </summary>
    public GdsContent? Title { get; set; }

    /// <summary>
    /// Sets heading level for the title only.
    /// You can only use values between 1 and 6 with this option.
    /// </summary>
    public int? TitleHeadingLevel { get; set; }

    /// <summary>
    /// The type of notification to render.
    /// You can use only the success or null values with this option.
    /// If you set type to success, the notification banner sets role to alert.
    /// JavaScript then moves the keyboard focus to the notification banner when the page loads.
    /// If you do not set type, the notification banner sets role to region.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Overrides the value of the role attribute for the notification banner.
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// The id for the banner title, and the aria-labelledby attribute in the banner.
    /// </summary>
    public string? TitleId { get; set; }

    /// <summary>
    /// If you set type to success, or role to alert, JavaScript moves the keyboard focus to the notification banner when the page loads.
    /// To disable this behaviour, set disableAutoFocus to true.
    /// </summary>
    public bool? DisableAutoFocus { get; set; }

    public NotificationBannerModel()
    {
    }

    public NotificationBannerModel(GdsContent content) : base(content)
    {
    }
}
