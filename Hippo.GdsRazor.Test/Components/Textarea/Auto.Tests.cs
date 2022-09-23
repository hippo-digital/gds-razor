using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(TextareaModel model)
    {
        var html = await AutoFixtureResults("Textarea", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);

        Assert.Contains(model.Name, html);
        Assert.Contains(model.Rows.ToString(), html);
        Assert.Contains(model.Value, html);
        Assert.Contains(model.DescribedBy, html);
        Assert.Contains(model.FormGroupClasses, html);
        Assert.Contains(model.Autocomplete, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Hint
        // Assert.Contains(model.Hint!.Id, html); Overridden in textarea
        Assert.Contains(model.Hint!.Classes, html);
        Assert.Contains(((GdsPlain) model.Hint.Content!).Text, html);

        foreach (var kv in model.Hint.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Label
        Assert.Contains(model.Label!.Id, html);
        Assert.Contains(model.Label.Classes, html);
        // Assert.Contains(model.Label.For, html); Overridden in textarea
        Assert.Contains(((GdsPlain) model.Label.Content!).Text, html);

        foreach (var kv in model.Label.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Error message
        // Assert.Contains(model.ErrorMessage!.Id, html); Overridden in textarea
        Assert.Contains(model.ErrorMessage!.Classes, html);
        Assert.Contains(model.ErrorMessage.VisuallyHiddenText, html);
        Assert.Contains(((GdsPlain) model.ErrorMessage.Content!).Text, html);

        foreach (var kv in model.ErrorMessage.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
