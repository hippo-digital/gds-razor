using AngleSharp;
using GdsRazor.Models;
using GdsRazor.Models.Content;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.SkipLink;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(SkipLinkModel model)
    {
        GdsCollection.Model = ("GdsSkipLink", model);
        var response = await Navigate("/Custom");
        var html = response.ToHtml();

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.Href, html);
        Assert.Contains(((GdsPlain) model.Content!).Text, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }
    }
}
