using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.NotificationBanner;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(NotificationBannerModel model)
    {
        var html = await AutoFixtureResults("NotificationBanner", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(((GdsPlain) model.Content!).Text, html);
        Assert.Contains(((GdsPlain) model.Title!).Text, html);
        Assert.Contains($"<h{model.TitleHeadingLevel}", html);
        //Assert.Contains(model.Type, html); Can only be success or not
        Assert.Contains(model.Role, html);
        Assert.Contains(model.TitleId, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
