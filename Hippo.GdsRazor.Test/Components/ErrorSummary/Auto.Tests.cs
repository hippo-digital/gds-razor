using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.ErrorSummary;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(ErrorSummaryModel model)
    {
        var html = await AutoFixtureResults("ErrorSummary", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(((GdsPlain) model.Title!).Text, html);
        Assert.Contains(((GdsPlain) model.Description!).Text, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        foreach (var action in model.ErrorList!)
        {
            Assert.Contains(action.Id, html);
            Assert.Contains(action.Classes, html);
            Assert.Contains(action.Href, html);
            Assert.Contains(((GdsPlain) action.Content!).Text, html);

            foreach (var kv in action.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
