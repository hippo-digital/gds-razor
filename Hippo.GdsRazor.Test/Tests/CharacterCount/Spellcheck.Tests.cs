using Hippo.GdsRazor.Test.Tests.Internal;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.CharacterCount;

public class SpellcheckTests : ClientBase<Startup>
{
    public SpellcheckTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToTrue()
    {
        var response = await Navigate("/CharacterCount/SpellcheckEnabled");
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Equal("true", component!.Attributes["spellcheck"]?.Value);
    }

    [Fact]
    public async void RendersTheTextareaWithSpellcheckAttributeSetToFalse()
    {
        var response = await Navigate("/CharacterCount/SpellcheckDisabled");
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Equal("false", component!.Attributes["spellcheck"]?.Value);
    }

    [Fact]
    public async void RendersTheTextareaWithoutSpellcheckAttributeByDefault()
    {
        var response = await Navigate("/CharacterCount/Default");
        var component = response.QuerySelector(".govuk-character-count .govuk-textarea");

        Assert.Null(component!.Attributes["spellcheck"]?.Value);
    }
}
