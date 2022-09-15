using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class WarningTextModel : GdsWithContent
{
    public string? IconFallbackText { get; set; }

    public WarningTextModel()
    {
    }

    public WarningTextModel(GdsContent content) : base(content)
    {
    }
}
