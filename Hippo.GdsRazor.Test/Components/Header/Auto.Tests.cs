using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Header;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(HeaderModel model)
    {
        var html = await AutoFixtureResults("Header", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.HomepageUrl, html);
        Assert.Contains(model.AssetsPath, html);
        Assert.Contains(model.ProductName, html);
        Assert.Contains(model.ServiceName, html);
        Assert.Contains(model.ServiceUrl, html);
        Assert.Contains(model.NavigationClasses, html);
        Assert.Contains(model.NavigationLabel, html);
        Assert.Contains(model.MenuButtonText, html);
        Assert.Contains(model.MenuButtonLabel, html);
        Assert.Contains(model.ContainerClasses, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Navigation
        foreach (var nav in model.Navigation!)
        {
            Assert.Contains(((GdsPlain) nav.Content!).Text, html);
            Assert.Contains(nav.Href, html);

            foreach (var kv in nav.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
