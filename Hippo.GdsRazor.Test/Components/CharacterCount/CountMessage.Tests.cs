using System.Text.RegularExpressions;
using Hippo.GdsRazor.Test.Components.Internal;
using Hippo.GdsRazor.Test.Controllers;
using Xunit;

namespace Hippo.GdsRazor.Test.Components.CharacterCount;

public class CountMessageTests : ClientBase<Startup>
{
    public CountMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithTheAmountOfCharactersExpected()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("You can enter up to 10 characters", countMessage!.TextContent);
    }

    [Fact]
    public async void RendersWithRows()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.WithWordCount));
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("You can enter up to 10 words", countMessage!.TextContent);
    }

    [Fact]
    public async void IsAssociatedWithTheTextarea()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.Default));
        var textarea = response.QuerySelector(".govuk-js-character-count");
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Matches(new Regex($"\\b{countMessage!.Id}\\b"), textarea!.GetAttribute(AriaDescribedBy) ?? "");
    }

    [Fact]
    public async void RendersWithCustomClasses()
    {
        var response = await Navigate("CharacterCount" ,nameof(CharacterCountController.CustomClassesOnCountMessage));
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("app-custom-count-message", countMessage!.ClassList);
    }
}
