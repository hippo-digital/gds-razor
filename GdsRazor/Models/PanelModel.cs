using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class PanelModel : GdsWithContent
{
    public GdsContent? Title { get; set; }
    public int? HeadingLevel { get; set; }

    public PanelModel()
    {
    }

    public PanelModel(GdsContent title, GdsContent content) : base(content)
    {
        Title = title;
    }
}
