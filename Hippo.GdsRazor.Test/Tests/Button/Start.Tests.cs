using AngleSharp.Svg.Dom;
using Hippo.GdsRazor.Test.Controllers;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Button;

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
