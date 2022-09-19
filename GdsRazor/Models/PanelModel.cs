using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// The panel component is a visible container used on confirmation or results pages to highlight important content.
/// </summary>
public class PanelModel : GdsWithContent
{
    /// <summary>
    /// Content to use within the panel.
    /// </summary>
    public GdsContent? Title { get; set; }

    /// <summary>
    /// Heading level, from 1 to 6.
    /// </summary>
    public int? HeadingLevel { get; set; }

    public PanelModel()
    {
    }

    public PanelModel(GdsContent title, GdsContent content) : base(content)
    {
        Title = title;
    }
}
