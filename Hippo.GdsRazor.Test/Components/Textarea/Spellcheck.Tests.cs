using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.Textarea;

public class SpellcheckTests : ClientBase<Startup>
{
    public SpellcheckTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToTrue()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithSpellcheckEnabled));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("true", component!.GetAttribute("spellcheck"));
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToFalse()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.WithSpellcheckDisabled));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Equal("false", component!.GetAttribute("spellcheck"));
    }

    [Fact]
    public async void RendersTheTextareaWithoutSpellcheckAttributeByDefault()
    {
        var response = await Navigate("Textarea" ,nameof(TextareaController.Default));
        var component = response.QuerySelector(".govuk-textarea");

        Assert.Null(component!.GetAttribute("spellcheck"));
    }
}
