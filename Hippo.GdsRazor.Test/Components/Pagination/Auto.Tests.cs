using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Pagination;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(PaginationModel model)
    {
        var html = await AutoFixtureResults("Pagination", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.LandmarkLabel, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Previous
        Assert.Contains(model.Previous!.Href, html);
        Assert.Contains(model.Previous.Text, html);
        // Assert.Contains(model.Previous.LabelText, html); Not used with items

        foreach (var kv in model.Previous.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Next
        Assert.Contains(model.Next!.Href, html);
        Assert.Contains(model.Next.Text, html);
        // Assert.Contains(model.Next.LabelText, html); Not used with items

        foreach (var kv in model.Next.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Items
        foreach (var item in model.Items!.OfType<PaginationModel.ItemModel>())
        {
            Assert.Contains(item.Number, html);
            Assert.Contains(item.VisuallyHiddenText, html);
            Assert.Contains(item.Href, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
