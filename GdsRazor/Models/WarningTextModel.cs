using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class WarningTextModel : GdsWithContent
{
    /// <summary>
    /// The fallback text for the icon.
    /// </summary>
    public string? IconFallbackText { get; set; }

    public WarningTextModel()
    {
    }

    public WarningTextModel(GdsContent content) : base(content)
    {
    }
}
