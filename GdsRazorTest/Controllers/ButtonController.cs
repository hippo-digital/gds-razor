using GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GdsRazorTest.Controllers;

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

    public IActionResult Default() => PartialView("GdsButton", Examples.Default);
    public IActionResult Disabled() => PartialView("GdsButton", Examples.Disabled);
    public IActionResult Link() => PartialView("GdsButton", Examples.Link);
    public IActionResult LinkDisabled() => PartialView("GdsButton", Examples.LinkDisabled);
    public IActionResult StartLink() => PartialView("GdsButton", Examples.StartLink);
    public IActionResult Input() => PartialView("GdsButton", Examples.Input);
    public IActionResult InputDisabled() => PartialView("GdsButton", Examples.InputDisabled);
    public IActionResult PreventDoubleClick() => PartialView("GdsButton", Examples.PreventDoubleClick);
    public IActionResult Attributes() => PartialView("GdsButton", Examples.Attributes);
    public IActionResult LinkAttributes() => PartialView("GdsButton", Examples.LinkAttributes);
    public IActionResult InputAttributes() => PartialView("GdsButton", Examples.InputAttributes);
    public IActionResult Classes() => PartialView("GdsButton", Examples.Classes);
    public IActionResult LinkClasses() => PartialView("GdsButton", Examples.LinkClasses);
    public IActionResult InputClasses() => PartialView("GdsButton", Examples.InputClasses);
    public IActionResult Name() => PartialView("GdsButton", Examples.Name);
    public IActionResult Type() => PartialView("GdsButton", Examples.Type);
    public IActionResult InputType() => PartialView("GdsButton", Examples.InputType);
    public IActionResult ExplicitLink() => PartialView("GdsButton", Examples.ExplicitLink);
    public IActionResult NoHref() => PartialView("GdsButton", Examples.NoHref);
    public IActionResult Value() => PartialView("GdsButton", Examples.Value);
    public IActionResult Html() => View();
    public IActionResult NoType() => PartialView("GdsButton", Examples.NoType);
    public IActionResult Axe() => View(Examples.Default);
}
