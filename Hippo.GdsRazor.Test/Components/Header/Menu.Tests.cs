using AngleSharp.Html.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class MenuTests : ClientBase<Startup>
{
    public MenuTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void HasAnExplicitTypeButtonSoItDoesNotActAsASubmitButton()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(component);
        Assert.Equal("button", ((IHtmlButtonElement) component!).Type);
    }

    [Fact]
    public async void HasAHiddenAttributeOnLoadSoThatItDoesNotShowAnUnusableButtonWithoutJs()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.IsAssignableFrom<IHtmlButtonElement>(component);
        Assert.True(((IHtmlButtonElement) component!).IsHidden);
    }

    [Fact]
    public async void RendersDefaultLabelCorrectly()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.Equal("Show or hide menu", component!.Attributes["aria-label"]?.Value);
    }

    [Fact]
    public async void AllowsLabelToBeCustomised()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithCustomMenuButtonLabel));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.Equal("Custom button label", component!.Attributes["aria-label"]?.Value);
    }

    [Fact]
    public async void RendersDefaultTextCorrectly()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.Equal("Menu", component!.TextContent.Trim());
    }

    [Fact]
    public async void AllowsTextToBeCustomised()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithCustomMenuButtonText));
        var component = response.QuerySelector(".govuk-header__menu-button");

        Assert.Equal("Dewislen", component!.TextContent.Trim());
    }
}
