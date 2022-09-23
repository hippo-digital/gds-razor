using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.DateInput;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(DateInputModel model)
    {
        var html = await AutoFixtureResults("DateInput", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.NamePrefix, html);
        Assert.Contains(model.FormGroupClasses, html);
        Assert.Contains(model.DescribedBy, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Hint
        // Assert.Contains(model.Hint!.Id, html); Overriden in dateinput
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
        // Assert.Contains(model.Fieldset.Role, html); Overriden in dateinput

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
        //Assert.Contains(model.ErrorMessage!.Id, html); Overriden in dateinput
        Assert.Contains(model.ErrorMessage!.Classes, html);
        Assert.Contains(model.ErrorMessage.VisuallyHiddenText, html);
        Assert.Contains(((GdsPlain) model.ErrorMessage.Content!).Text, html);

        foreach (var kv in model.ErrorMessage.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        //Items
        foreach (var item in model.Items.OfType<DateInputModel.ItemModel>())
        {
            Assert.Contains(item.Id, html);
            Assert.Contains(item.Classes, html);
            Assert.Contains(item.Name, html);
            Assert.Contains(item.Label, html);
            Assert.Contains(item.Value, html);
            Assert.Contains(item.Inputmode, html);
            Assert.Contains(item.Autocomplete, html);
            Assert.Contains(item.Pattern, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
