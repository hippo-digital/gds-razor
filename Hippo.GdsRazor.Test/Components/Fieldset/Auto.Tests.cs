using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Fieldset;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(FieldsetModel model)
    {
        var html = await AutoFixtureResults("Fieldset", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.DescribedBy, html);
        Assert.Contains(model.Role, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Legend
        Assert.Contains(model.Legend!.Id, html);
        Assert.Contains(model.Legend.Classes, html);
        Assert.Contains(((GdsPlain) model.Legend.Content!).Text, html);

        foreach (var kv in model.Legend.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
