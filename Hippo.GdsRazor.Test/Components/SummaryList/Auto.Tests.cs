using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.SummaryList;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(SummaryListModel model)
    {
        var html = await AutoFixtureResults("SummaryList", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Rows
        foreach (var item in model.Rows!)
            AllRowPropertiesAreUsed(item, html);
    }

    private static void AllRowPropertiesAreUsed(SummaryListModel.RowModel row, string html)
    {
        Assert.Contains(row.Id, html);
        Assert.Contains(row.Classes, html);
        Assert.Contains(row.ActionsClasses, html);

        foreach (var kv in row.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Key
        Assert.Contains(row.Key!.Id, html);
        Assert.Contains(row.Key.Classes, html);
        Assert.Contains(((GdsPlain) row.Key.Content!).Text, html);

        foreach (var kv in row.Key.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Value
        Assert.Contains(row.Value!.Id, html);
        Assert.Contains(row.Value.Classes, html);
        Assert.Contains(((GdsPlain) row.Value.Content!).Text, html);

        foreach (var kv in row.Value.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Actions
        foreach (var action in row.Actions!)
        {
            Assert.Contains(action.Id, html);
            Assert.Contains(action.Classes, html);
            Assert.Contains(action.Href, html);
            Assert.Contains(action.VisuallyHiddenText, html);
            Assert.Contains(((GdsPlain) action.Content!).Text, html);

            foreach (var kv in action.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
