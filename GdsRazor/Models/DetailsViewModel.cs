using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class DetailsModel : GdsWithContent
{
    public GdsContent? Summary { get; set; }
    public bool Open { get; set; }

    public DetailsModel()
    {
    }

    public DetailsModel(GdsContent summary, GdsContent content) : base(content)
    {
        Summary = summary;
    }
}
