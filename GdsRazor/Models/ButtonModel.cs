using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class ButtonModel : GdsWithHref
{
    private string? _element;
    /// <summary>
    /// Whether to use an input, button or a element to create the button.
    /// In most cases you will not need to set this as it will be configured automatically.
    /// </summary>
    public string? Element
    {
        get => _element?.ToLower() ?? (string.IsNullOrEmpty(Href) ? "button" : "a");
        set => _element = value;
    }

    /// <summary>
    /// Name for the input or button.
    /// This has no effect on a elements.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Type of input or button – button, submit or reset.
    /// Defaults to submit. This has no effect on a elements.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Value for the button tag.
    /// This has no effect on a or input elements.
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Whether the button should be disabled.
    /// For button and input elements, disabled and aria-disabled attributes will be set automatically.
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// Prevent accidental double clicks on submit buttons from submitting forms multiple times.
    /// </summary>
    public bool PreventDoubleClick { get; set; }

    /// <summary>
    /// Use for the main call to action on your service's start page.
    /// </summary>
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
