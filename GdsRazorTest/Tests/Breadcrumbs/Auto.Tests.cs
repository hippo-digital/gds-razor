using AngleSharp;
using GdsRazor.Models;
using GdsRazor.Models.Content;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Breadcrumbs;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(BreadcrumbsModel model)
    {
        GdsCollection.Model = ("GdsBreadcrumbs", model);
        var response = await Navigate("/Custom");
        var html = response.ToHtml();

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        foreach (var item in model.Items!)
        {
            // Assert.Contains(item.VisuallyHiddenText, html); Currently unused in breadcrumbs
            Assert.Contains(item.Id, html);
            Assert.Contains(item.Href, html);
            Assert.Contains(((GdsPlain) item.Content!).Text, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }
    }
}
