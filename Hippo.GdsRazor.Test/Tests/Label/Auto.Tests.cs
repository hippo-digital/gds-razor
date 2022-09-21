using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Label;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(LabelModel model)
    {
        var html = await AutoFixtureResults("Label", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.For, html);
        Assert.Contains(((GdsPlain) model.Content!).Text, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
