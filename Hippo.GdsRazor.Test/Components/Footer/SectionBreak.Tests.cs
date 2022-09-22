using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class SectionBreakTests : ClientBase<Startup>
{
    public SectionBreakTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWhenThereIsANavigation()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithNavigation));
        var components = response.QuerySelectorAll("hr.govuk-footer__section-break");

        Assert.NotEmpty(components);
    }

    [Fact]
    public async void RendersNothingWhenThereIsOnlyMeta()
    {
        var response = await Navigate("Footer" ,nameof(FooterController.WithMeta));
        var components = response.QuerySelectorAll("hr.govuk-footer__section-break");

        Assert.Empty(components);
    }
}
