using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Hippo.GdsRazor.Test.Components.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Footer;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(FooterModel model)
    {
        var html = await AutoFixtureResults("Footer", model);

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains(((GdsPlain) model.ContentLicense!).Text, html);
        Assert.Contains(((GdsPlain) model.Copyright!).Text, html);
        Assert.Contains(model.ContainerClasses, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        // Meta
        Assert.Contains(model.Meta!.VisuallyHiddenTitle, html);
        Assert.Contains(((GdsPlain) model.Meta.Content!).Text, html);

        foreach (var item in model.Meta.Items!)
        {
            Assert.Contains(item.Text, html);
            Assert.Contains(item.Href, html);

            foreach (var kv in item.Attributes!)
            {
                Assert.Contains(kv.Key, html);
                Assert.Contains(kv.Value, html);
            }
        }

        // Navigation
        foreach (var nav in model.Navigation!)
        {
            Assert.Contains(nav.Title, html);

            foreach (var item in nav.Items!)
            {
                Assert.Contains(item.Text, html);
                Assert.Contains(item.Href, html);

                foreach (var kv in item.Attributes!)
                {
                    Assert.Contains(kv.Key, html);
                    Assert.Contains(kv.Value, html);
                }
            }
        }
    }
}
