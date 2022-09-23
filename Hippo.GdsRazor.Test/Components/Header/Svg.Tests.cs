using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class SvgTests : ClientBase<Startup>
{
    public SvgTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void SetsFocusableFalseSoThatIeDoesNotTreatItAsAnInteractiveElement()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.Default));
        var component = response.QuerySelector(".govuk-header__logotype-crown");

        Assert.Equal("false", component!.Attributes["focusable"]?.Value);
    }

    [Fact]
    public async void SetsAriaHiddenTrueSoThatItIsIgnoredByAssistiveTechnologies()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.Default));
        var component = response.QuerySelector(".govuk-header__logotype-crown");

        Assert.Equal("true", component!.Attributes["aria-hidden"]?.Value);
    }

    [Fact]
    public async void FallbackPngIsInvisibleToModerBrowsers()
    {
        var response = await Navigate("Header" ,nameof(HeaderController.WithNavigation));
        var components = response.QuerySelectorAll(".govuk-header__logotype-crown-fallback-image");

        Assert.Empty(components);
    }
}
