using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Select;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(SelectModel model)
    {
        var html = await AutoFixtureResults("Select", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.Name, html);
        // Assert.Contains(model.Value, html); // Not passed to page
        Assert.Contains(model.DescribedBy, html);
        Assert.Contains(model.FormGroupClasses, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Hint
        // Assert.Contains(model.Hint!.Id, html); Overriden by select
        Assert.Contains(model.Hint!.Classes, html);
        Assert.Contains(((GdsPlain) model.Hint.Content!).Text, html);

        foreach (var kv in model.Hint.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Error message
        // Assert.Contains(model.ErrorMessage!.Id, html); Overriden by select
        Assert.Contains(model.ErrorMessage!.Classes, html);
        Assert.Contains(model.ErrorMessage.VisuallyHiddenText, html);
        Assert.Contains(((GdsPlain) model.ErrorMessage.Content!).Text, html);

        foreach (var kv in model.ErrorMessage.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        //Items
        foreach (var item in model.Items!.OfType<SelectModel.ItemModel>())
        {
            Assert.Contains(item.Value, html);
            Assert.Contains(item.Text, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
