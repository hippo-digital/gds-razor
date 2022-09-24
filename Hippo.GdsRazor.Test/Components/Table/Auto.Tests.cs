using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Table;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(TableModel model)
    {
        var html = await AutoFixtureResults("Table", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.Caption, html);
        Assert.Contains(model.CaptionClasses, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        ValidateRow(model.Head!, html);
        
        // Rows
        foreach (var row in model.Rows!)
        {
            ValidateRow(row, html);
        }
    }

    private static void ValidateRow(TableModel.RowModel row, string html)
    {
        Assert.Contains(row.Id, html);
        Assert.Contains(row.Classes, html);

        foreach (var kv in row.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
        
        foreach (var cell in row.Cells!)
        {
            Assert.Contains(cell.Id, html);
            Assert.Contains(cell.Classes, html);
            Assert.Contains(((GdsPlain) cell.Content!).Text, html);
            Assert.Contains(cell.Format, html);
            Assert.Contains(cell.Colspan.ToString(), html);
            Assert.Contains(cell.Rowspan.ToString(), html);

            foreach (var kv in cell.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
