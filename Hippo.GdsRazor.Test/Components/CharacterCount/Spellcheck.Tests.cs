using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class SpellcheckTests : ClientBase<Startup>
{
    public SpellcheckTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToTrue()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.SpellcheckEnabled));
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Equal("true", component!.Attributes["spellcheck"]?.Value);
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToFalse()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.SpellcheckDisabled));
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Equal("false", component!.Attributes["spellcheck"]?.Value);
    }

    [Fact]
    public async void RendersTheTextareaWithoutSpellcheckAttributeByDefault()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Null(component!.Attributes["spellcheck"]?.Value);
    }
}
