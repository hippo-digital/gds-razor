using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.PhaseBanner;

public class DependantTests : ClientBase<Startup>
{
    public DependantTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheTagComponentText()
    {
        var response = await Navigate("/PhaseBanner/Default");
        var component = response.QuerySelector(".govuk-phase-banner__content__tag");

        const string expected = "<strong class=\"govuk-tag govuk-phase-banner__content__tag \">\n  \nalpha\n</strong>";

        Assert.Equal(expected, component!.OuterHtml);
    }

    [Fact]
    public async void RendersTheTagComponentHtml()
    {
        var response = await Navigate("/PhaseBanner/TagHtml");
        var component = response.QuerySelector(".govuk-phase-banner__content__tag");

        const string expected = "<strong class=\"govuk-tag govuk-phase-banner__content__tag \">\n  \n<em>alpha</em>\n</strong>";

        Assert.Equal(expected, component!.OuterHtml);
    }

    [Fact]
    public async void RendersTheTagComponentClasses()
    {
        var response = await Navigate("/PhaseBanner/TagClasses");
        var component = response.QuerySelector(".govuk-phase-banner__content__tag");

        const string expected = "<strong class=\"govuk-tag govuk-phase-banner__content__tag govuk-tag--grey\">\n  \nalpha\n</strong>";

        Assert.Equal(expected, component!.OuterHtml);
    }
}
