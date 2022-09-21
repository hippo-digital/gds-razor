using AngleSharp;
using GdsRazor.Models;
using GdsRazor.Models.Content;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.CookieBanner;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(CookieBannerModel model)
    {
        GdsCollection.Model = ("GdsCookieBanner", model);
        var response = await Navigate("/Custom");
        var html = response.ToHtml();

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(model.AriaLabel, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        foreach (var message in model.Messages!)
        {
            Assert.Contains(message.Id, html);
            Assert.Contains(message.Classes, html);
            Assert.Contains(message.Role, html);
            Assert.Contains(((GdsPlain) message.Content!).Text, html);
            Assert.Contains(((GdsPlain) message.Heading!).Text, html);

            foreach (var kv in message.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
            
            foreach (var action in message.Actions!)
            {
                Assert.Contains(action.Id, html);
                Assert.Contains(action.Classes, html);
                Assert.Contains(action.Text, html);
                // Assert.Contains(action.Type, html); Type isn't used on the page, possibly should use polymorphism
                Assert.Contains(action.Href, html);
                // Assert.Contains(action.Name, html); Only used when href is empty
                // Assert.Contains(action.Value, html); Only used when href is empty

                foreach (var kv in action.Attributes!)
                {
                    Assert.Contains(kv.Key, html);
                    Assert.Contains(kv.Value, html);
                }
            }
        }
    }
}
