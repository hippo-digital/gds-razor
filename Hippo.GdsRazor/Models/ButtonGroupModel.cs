using Hippo.GdsRazor.Models.Base;

namespace Hippo.GdsRazor.Models;

public class ButtonGroupModel : GdsViewModel
{
    public IEnumerable<ButtonModel>? Buttons { get; set; }

    public ButtonGroupModel()
    {
    }

    public ButtonGroupModel(IEnumerable<ButtonModel> buttons) : this()
    {
        Buttons = buttons;
    }

    public ButtonGroupModel(params ButtonModel[] buttons) : this(buttons.ToList())
    {
    }
}
