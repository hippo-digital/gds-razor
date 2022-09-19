using AngleSharp;
using GdsRazor.Models;
using GdsRazor.Models.Content;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.Accordion;

public class AutoTests : ClientBase<Startup>
{
    public AutoTests(CustomWebApplicationFactory<Startup> factory) : base(factory) { }

    [Theory, GdsAutoData]
    public async void AllPropertiesAreUsed(AccordionModel model)
    {
        GdsCollection.Model = ("GdsAccordion", model);
        var response = await Navigate("/Custom");
        var html = response.ToHtml();

        Assert.Contains(model.Id, html);
        Assert.Contains(model.Classes, html);
        Assert.Contains($"<h{model.HeadingLevel}", html);
        Assert.Contains(model.HideAllSectionsText, html);
        Assert.Contains(model.HideSectionText, html);
        Assert.Contains(model.ShowAllSectionsText, html);
        Assert.Contains(model.ShowSectionText, html);

        foreach (var kv in model.Attributes!)
        {
            Assert.Contains(kv.Key, html);
            Assert.Contains(kv.Value, html);
        }

        foreach (var item in model.Items!)
        {
            Assert.Contains(((GdsPlain) item.Heading!).Text, html);
            Assert.Contains(((GdsPlain) item.Content!).Text, html);
            Assert.Contains(((GdsPlain) item.Summary!).Text, html);
        }
    }
}
