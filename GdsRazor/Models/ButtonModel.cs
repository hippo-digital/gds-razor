using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class ButtonModel : GdsWithHref
{
    private string? _element;
    public string? Element
    {
        get => _element?.ToLower() ?? (string.IsNullOrEmpty(Href) ? "button" : "a");
        set => _element = value;
    }

    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Value { get; set; }
    public bool Disabled { get; set; }
    public bool PreventDoubleClick { get; set; }
    public bool IsStartButton { get; set; }

    public string AllClasses() => Classes +
                                  (Disabled ? " govuk-button--disabled" : "") +
                                  (IsStartButton ? " govuk-button--start" : "");

    public ButtonModel()
    {
    }

    public ButtonModel(GdsContent content) : base(content)
    {
    }

    public static class Colors
    {
        public const string Secondary = "govuk-button--secondary";
        public const string Warning = "govuk-button--warning";
    }
}
