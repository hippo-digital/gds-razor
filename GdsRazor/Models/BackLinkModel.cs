using GdsRazor.Models.Base;

namespace GdsRazor.Models;

/// <summary>
/// Use the back link component to help users go back to the previous page in a multi-page transaction.
/// 
/// Although browsers have a back button, some sites break when you use it - so many users avoid it, instead of losing their progress in a service.
/// Also, not all users are aware of the back button.
/// </summary>
public class BackLinkModel : GdsWithHref
{
    public BackLinkModel()
    {
        Content = "Back";
    }

    public BackLinkModel(string href) : this()
    {
        Href = href;
    }
}
