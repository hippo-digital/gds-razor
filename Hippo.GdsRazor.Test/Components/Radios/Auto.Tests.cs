using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Radios;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(RadiosModel model)
    {
        var html = await AutoFixtureResults("Radios", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.DescribedBy, html);
        Assert.Contains(model.FormGroupClasses, html);
        Assert.Contains(model.IdPrefix, html);
        Assert.Contains(model.Name, html); // Overriden by item names

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Hint
        // Assert.Contains(model.Hint!.Id, html);
        Assert.Contains(model.Hint!.Classes, html);
        Assert.Contains(((GdsPlain) model.Hint.Content!).Text, html);

        foreach (var kv in model.Hint.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Fieldset
        Assert.Contains(model.Fieldset!.Id, html);
        Assert.Contains(model.Fieldset.Classes, html);
        Assert.Contains(model.Fieldset.DescribedBy, html);
        Assert.Contains(model.Fieldset.Role, html);

        foreach (var kv in model.Fieldset!.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Fieldset legend
        Assert.Contains(model.Fieldset.Legend!.Id, html);
        Assert.Contains(model.Fieldset.Legend.Classes, html);
        Assert.Contains(((GdsPlain) model.Fieldset.Legend!.Content!).Text, html);

        foreach (var kv in model.Fieldset.Legend.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Error message
        // Assert.Contains(model.ErrorMessage!.Id, html); Overriden by Radios
        Assert.Contains(model.ErrorMessage!.Classes, html);
        Assert.Contains(model.ErrorMessage.VisuallyHiddenText, html);
        Assert.Contains(((GdsPlain) model.ErrorMessage.Content!).Text, html);

        foreach (var kv in model.ErrorMessage.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Items
        foreach (var item in model.Items!.OfType<RadiosModel.ItemModel>())
            AllItemPropertiesAreUsed(item, html);
    }

    private static void AllItemPropertiesAreUsed(RadiosModel.ItemModel item, string html)
    {
        Assert.Contains(item.Id, html);
        Assert.Contains(item.Classes, html);
        Assert.Contains(item.Value, html);
        Assert.Contains(((GdsPlain) item.Content!).Text, html);
        Assert.Contains(((GdsPlain) item.ConditionalContent!).Text, html);

        foreach (var kv in item.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Item Hint
        // Assert.Contains(item.Hint!.Id, html); Overriden by Radios
        Assert.Contains(item.Hint!.Classes, html);
        Assert.Contains(((GdsPlain) item.Hint.Content!).Text, html);

        foreach (var kv in item.Hint.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Item Label
        Assert.Contains(item.Label!.Id, html);
        Assert.Contains(item.Label.Classes, html);
        // Assert.Contains(item.Label.For, html); Overriden by Radios
        // Assert.Contains(((GdsPlain) item.Label.Content!).Text, html); Overriden by Radios

        foreach (var kv in item.Label.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
