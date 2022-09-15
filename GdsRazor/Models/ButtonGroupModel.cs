using GdsRazor.Models.Base;

namespace GdsRazor.Models;

public class ButtonGroupModel : GdsViewModel
{
    public List<ButtonModel>? Buttons { get; set; }

    public ButtonGroupModel()
    {
    }

    public ButtonGroupModel(List<ButtonModel> buttons) : this()
    {
        Buttons = buttons;
    }

    public ButtonGroupModel(params ButtonModel[] buttons) : this(buttons.ToList())
    {
    }
}
