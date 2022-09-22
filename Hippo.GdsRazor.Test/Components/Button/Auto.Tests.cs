using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Button;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(ButtonModel model)
    {
        var html = "";

        // Render link and input views
        foreach (var s in new [] {"a", "input"})
        {
            model.Element = s;
            html += await AutoFixtureResults("Button", model);
        }

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.Name, html);
        Assert.Contains(model.Type, html);
        Assert.Contains(model.Value, html);
        Assert.Contains(model.Href, html);
        Assert.Contains(((GdsPlain) model.Content!).Text, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
