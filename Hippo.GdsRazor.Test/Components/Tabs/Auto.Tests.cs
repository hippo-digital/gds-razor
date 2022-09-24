using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Tabs;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(TabsModel model)
    {
        var html = await AutoFixtureResults("Tabs", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        // Assert.Contains(model.IdPrefix, html); Only used if id is not on items
        Assert.Contains(model.Title, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Items
        foreach (var item in model.Items!)
        {
            Assert.Contains(item.Id, html);
            Assert.Contains(item.Classes, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }

            // Assert.Contains(item.Panel!.Id, html); Only id from item is used
            Assert.Contains(item.Panel!.Classes, html);
            Assert.Contains(((GdsPlain) item.Panel.Content!).Text, html);

            foreach (var kv in item.Panel.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
