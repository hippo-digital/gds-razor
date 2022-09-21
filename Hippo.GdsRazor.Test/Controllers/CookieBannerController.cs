using Hippo.GdsRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hippo.GdsRazor.Test.Controllers;

public class CookieBannerController : Controller
{
    private static class Examples
    {
        public static readonly CookieBannerModel Default = new(
            new CookieBannerModel.MessageModel("We use analytics cookies to help understand how users use our service.") {
                Heading = "Cookies on this government service",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Accept analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "accept"
                    },
                    new("Reject analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "reject"
                    },
                    new("View cookie preferences") {
                        Href = "/cookie-preferences"
                    }
                }
            }
        );
        public static readonly CookieBannerModel HeadingHtmlAsText = new(
            new CookieBannerModel.MessageModel {
                Heading = "Cookies on <span>my service</span>"
            }
        );
        public static readonly CookieBannerModel Classes = new(
            new CookieBannerModel.MessageModel {
                Classes = "app-my-class"
            }
        );
        public static readonly CookieBannerModel Attributes = new(
            new CookieBannerModel.MessageModel {
                Attributes = new Dictionary<string, string?> {{"data-attribute", "my-value"}}
            }
        );
        public static readonly CookieBannerModel CustomAriaLabel = new(
            new CookieBannerModel.MessageModel("We use cookies on GOV.UK")
        ) {
            AriaLabel = "Cookies on GOV.UK"
        };
        public static readonly CookieBannerModel AcceptedConfirmationBanner = new(
            new CookieBannerModel.MessageModel("Your cookie preferences have been saved. You have accepted cookies.") {
                Role = "alert",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Hide cookie message") {
                        Type = "button"
                    }
                }
            }
        );
        public static readonly CookieBannerModel Hidden = new(
            new CookieBannerModel.MessageModel {
                Hidden = true
            }
        );
        public static readonly CookieBannerModel HiddenFalse = new(
            new CookieBannerModel.MessageModel {
                Hidden = false
            }
        );
        public static readonly CookieBannerModel DefaultAction = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This is a button")
                }
            }
        );
        public static readonly CookieBannerModel Link = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This is a link") {
                        Href = "/link"
                    }
                }
            }
        );
        public static readonly CookieBannerModel LinkClasses = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This with custom classes") {
                        Href = "/link",
                        Classes = "my-link-class app-link-class"
                    }
                }
            }
        );
        public static readonly CookieBannerModel LinkAttributes = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This with attributes") {
                        Href = "/link",
                        Attributes = new Dictionary<string, string?> {{"data-link-attribute", "my-value"}}
                    }
                }
            }
        );
        public static readonly CookieBannerModel LinkWithFalseButtonOptions = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This is a link") {
                        Href = "/link",
                        Value = "cookies",
                        Name = "link"
                    }
                }
            }
        );
        public static readonly CookieBannerModel LinkAsAButton = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("This is a link") {
                        Href = "/link",
                        Type = "button"
                    }
                }
            }
        );
        public static readonly CookieBannerModel Type = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Button") {
                        Type = "button"
                    }
                }
            }
        );
        public static readonly CookieBannerModel ButtonClasses = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Button with custom classes") {
                        Classes = "my-button-class app-button-class"
                    }
                }
            }
        );
        public static readonly CookieBannerModel ButtonAttributes = new(
            new CookieBannerModel.MessageModel {
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Button with attributes") {
                        Attributes = new Dictionary<string, string?> {{"data-button-attribute", "my-value"}}
                    }
                }
            }
        );
        public static readonly CookieBannerModel ClientSideImplementation = new(
            new CookieBannerModel.MessageModel("We use cookies to help understand how users use our service.") {
                Heading = "Cookies on this service",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Accept analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "accept"
                    },
                    new("Reject analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "reject"
                    },
                    new("View cookie preferences") {
                        Href = "/cookie-preferences"
                    }
                }
            },
            new CookieBannerModel.MessageModel("Your cookie preferences have been saved. You have accepted cookies.") {
                Role = "alert",
                Hidden = true,
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Hide cookie message") {
                        Type = "button"
                    }
                }
            },
            new CookieBannerModel.MessageModel("Your cookie preferences have been saved. You have rejected cookies.") {
                Role = "alert",
                Hidden = true,
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Hide cookie message") {
                        Type = "button"
                    }
                }
            }
        );
        public static readonly CookieBannerModel FullBannerHidden = new(
            new CookieBannerModel.MessageModel("We use cookies to help understand how users use our service.") {
                Heading = "Cookies on this service",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Accept analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "accept"
                    },
                    new("Reject analytics cookies") {
                        Type = "submit",
                        Name = "cookies",
                        Value = "reject"
                    },
                    new("View cookie preferences") {
                        Href = "/cookie-preferences"
                    }
                }
            },
            new CookieBannerModel.MessageModel("Your cookie preferences have been saved. You have accepted cookies.") {
                Role = "alert",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Hide cookie message") {
                        Type = "button"
                    }
                }
            },
            new CookieBannerModel.MessageModel("Your cookie preferences have been saved. You have rejected cookies.") {
                Role = "alert",
                Actions = new List<CookieBannerModel.MessageModel.ActionModel> {
                    new("Hide cookie message") {
                        Type = "button"
                    }
                }
            }
        ) {
            Hidden = true,
            Classes = "hide-cookie-banner",
            Attributes = new Dictionary<string, string?> {{"data-hide-cookie-banner", "true"}}
        };
    }

    public IActionResult Default() => PartialView("GdsCookieBanner", Examples.Default);
    public IActionResult HeadingHtmlAsText() => PartialView("GdsCookieBanner", Examples.HeadingHtmlAsText);
    public IActionResult HeadingHtml() => View();
    public IActionResult Classes() => PartialView("GdsCookieBanner", Examples.Classes);
    public IActionResult Html() => View();
    public IActionResult Attributes() => PartialView("GdsCookieBanner", Examples.Attributes);
    public IActionResult CustomAriaLabel() => PartialView("GdsCookieBanner", Examples.CustomAriaLabel);
    public IActionResult AcceptedConfirmationBanner() => PartialView("GdsCookieBanner", Examples.AcceptedConfirmationBanner);
    public IActionResult Hidden() => PartialView("GdsCookieBanner", Examples.Hidden);
    public IActionResult HiddenFalse() => PartialView("GdsCookieBanner", Examples.HiddenFalse);
    public IActionResult DefaultAction() => PartialView("GdsCookieBanner", Examples.DefaultAction);
    public IActionResult Link() => PartialView("GdsCookieBanner", Examples.Link);
    public IActionResult LinkClasses() => PartialView("GdsCookieBanner", Examples.LinkClasses);

    public IActionResult LinkAttributes() => PartialView("GdsCookieBanner", Examples.LinkAttributes);

    public IActionResult LinkWithFalseButtonOptions() => PartialView("GdsCookieBanner", Examples.LinkWithFalseButtonOptions);
    public IActionResult LinkAsAButton() => PartialView("GdsCookieBanner", Examples.LinkAsAButton);
    public IActionResult Type() => PartialView("GdsCookieBanner", Examples.Type);
    public IActionResult ButtonClasses() => PartialView("GdsCookieBanner", Examples.ButtonClasses);
    public IActionResult ButtonAttributes() => PartialView("GdsCookieBanner", Examples.ButtonAttributes);
    public IActionResult ClientSideImplementation() => PartialView("GdsCookieBanner", Examples.ClientSideImplementation);
    public IActionResult FullBannerHidden() => PartialView("GdsCookieBanner", Examples.FullBannerHidden);
    public IActionResult Axe() => View(Examples.Default);
    public IActionResult AxeConfirmation() => View("Axe", Examples.AcceptedConfirmationBanner);
}
