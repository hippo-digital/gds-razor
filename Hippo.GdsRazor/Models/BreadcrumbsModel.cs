using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// The breadcrumbs component helps users to understand where they are within a website's structure and move between levels.
/// </summary>
public class BreadcrumbsModel : GdsViewModel
{
    /// <summary>
    /// Array of breadcrumbs item objects.
    /// </summary>
    public List<LinkModel>? Items { get; set; }

    /// <summary>
    /// When true, the breadcrumbs will collapse to the first and last item only on tablet breakpoint and below.
    /// </summary>
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
