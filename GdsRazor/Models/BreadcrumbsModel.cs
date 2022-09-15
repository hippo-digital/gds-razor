using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class BreadcrumbsModel : GdsViewModel
{
    public List<LinkModel>? Items { get; set; }

    public bool CollapseOnMobile { get; set; }

    public BreadcrumbsModel()
    {
    }

    public BreadcrumbsModel(List<LinkModel> items) : this()
    {
        Items = items;
    }

    public BreadcrumbsModel(params LinkModel[] items) : this(items.ToList())
    {
    }
}
