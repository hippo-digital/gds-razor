using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Breadcrumbs;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(BreadcrumbsModel model)
    {
        var html = await AutoFixtureResults("Breadcrumbs", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        foreach (var item in model.Items!)
        {
            // Assert.Contains(item.VisuallyHiddenText, html); Currently unused in breadcrumbs
            Assert.Contains(item.Id, html);
            Assert.Contains(item.Href, html);
            Assert.Contains(((GdsPlain) item.Content!).Text, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
