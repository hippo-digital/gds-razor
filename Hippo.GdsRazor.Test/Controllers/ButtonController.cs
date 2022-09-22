using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class ButtonController : Controller
{
    private static class Examples
    {
        public static readonly ButtonModel Default = new("Save and continue");
        public static readonly ButtonModel Disabled = new("Disabled button") { Disabled = true };
        public static readonly ButtonModel Link = new("Link button") { Href = "/" };
        public static readonly ButtonModel LinkDisabled = new("Disabled link button") { Href = "/", Disabled = true };
        public static readonly ButtonModel StartLink = new("Start now button") { Href = "/", IsStartButton = true };
        public static readonly ButtonModel Input = new("Start now") { Element = "input", Name = "start-now" };
        public static readonly ButtonModel InputDisabled = new("Explicit input button disabled") { Element = "input", Disabled = true };
        public static readonly ButtonModel PreventDoubleClick = new("Submit") { PreventDoubleClick = true };
        public static readonly ButtonModel Attributes = new("Submit")
        {
            Element = "button",
            Attributes = new Dictionary<string, string?> {{"aria-controls", "example-id"}, {"data-tracking-dimension", "123"}}
        };
        public static readonly ButtonModel LinkAttributes = new("Submit")
        {
            Element = "a",
            Attributes = new Dictionary<string, string?> {{"aria-controls", "example-id"}, {"data-tracking-dimension", "123"}}
        };
        public static readonly ButtonModel InputAttributes = new("Submit")
        {
            Element = "input",
            Attributes = new Dictionary<string, string?> {{"aria-controls", "example-id"}, {"data-tracking-dimension", "123"}}
        };
        public static readonly ButtonModel Classes = new("Submit") { Element = "button", Classes = "app-button--custom-modifier" };
        public static readonly ButtonModel LinkClasses = new("Submit") { Element = "a", Classes = "app-button--custom-modifier" };
        public static readonly ButtonModel InputClasses = new("Submit") { Element = "input", Classes = "app-button--custom-modifier" };
        public static readonly ButtonModel Name = new("Submit") { Element = "button", Name = "start-now" };
        public static readonly ButtonModel Type = new("Submit") { Element = "button", Type = "button" };
        public static readonly ButtonModel InputType = new("Submit") { Element = "input", Type = "button" };
        public static readonly ButtonModel ExplicitLink = new("Continue") { Element = "a", Href = "/" };
        public static readonly ButtonModel NoHref = new("Submit") { Element = "a" };
        public static readonly ButtonModel Value = new("Submit") { Element = "button", Value = "start" };
        public static readonly ButtonModel NoType = new("Button!");
    }

    private const string PartialName = "GdsButton";
    public IActionResult Default() => PartialView(PartialName, Examples.Default);
    public IActionResult Disabled() => PartialView(PartialName, Examples.Disabled);
    public IActionResult Link() => PartialView(PartialName, Examples.Link);
    public IActionResult LinkDisabled() => PartialView(PartialName, Examples.LinkDisabled);
    public IActionResult StartLink() => PartialView(PartialName, Examples.StartLink);
    public IActionResult Input() => PartialView(PartialName, Examples.Input);
    public IActionResult InputDisabled() => PartialView(PartialName, Examples.InputDisabled);
    public IActionResult PreventDoubleClick() => PartialView(PartialName, Examples.PreventDoubleClick);
    public IActionResult Attributes() => PartialView(PartialName, Examples.Attributes);
    public IActionResult LinkAttributes() => PartialView(PartialName, Examples.LinkAttributes);
    public IActionResult InputAttributes() => PartialView(PartialName, Examples.InputAttributes);
    public IActionResult Classes() => PartialView(PartialName, Examples.Classes);
    public IActionResult LinkClasses() => PartialView(PartialName, Examples.LinkClasses);
    public IActionResult InputClasses() => PartialView(PartialName, Examples.InputClasses);
    public IActionResult Name() => PartialView(PartialName, Examples.Name);
    public IActionResult Type() => PartialView(PartialName, Examples.Type);
    public IActionResult InputType() => PartialView(PartialName, Examples.InputType);
    public IActionResult ExplicitLink() => PartialView(PartialName, Examples.ExplicitLink);
    public IActionResult NoHref() => PartialView(PartialName, Examples.NoHref);
    public IActionResult Value() => PartialView(PartialName, Examples.Value);
    public IActionResult Html() => View();
    public IActionResult NoType() => PartialView(PartialName, Examples.NoType);
    public IActionResult Axe() => View(Examples.Default);
}
