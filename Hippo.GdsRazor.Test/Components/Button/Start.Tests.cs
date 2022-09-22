using AngleSharp.Svg.Dom;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Button;

public class StartTests : ClientBase<Startup>
{
    public StartTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Fact]
    public async void RendersAnSvg()
    {
        var response = await Navigate("Button" ,nameof(ButtonController.StartLink));
        var component = response.QuerySelector(".govuk-button .govuk-button__start-icon");

        Assert.IsAssignableFrom<ISvgElement>(component);
    }
}
