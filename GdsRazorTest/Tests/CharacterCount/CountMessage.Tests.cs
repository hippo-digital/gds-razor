using System.Text.RegularExpressions;
using GdsRazorTest.Tests.Internal;
using Xunit;

namespace GdsRazorTest.Tests.CharacterCount;

public class CountMessageTests : ClientBase<Startup>
{
    public CountMessageTests(CustomWebApplicationFactory<Startup> factory) : base(factory)
    {
    }

    [Fact]
    public async void RendersWithTheAmountOfCharactersExpected()
    {
        var response = await Navigate("/CharacterCount/Default");
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("You can enter up to 10 characters", countMessage!.TextContent);
    }

    [Fact]
    public async void RendersWithRows()
    {
        var response = await Navigate("/CharacterCount/WithWordCount");
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("You can enter up to 10 words", countMessage!.TextContent);
    }

    [Fact]
    public async void IsAssociatedWithTheTextarea()
    {
        var response = await Navigate("/CharacterCount/Default");
        var textarea = response.QuerySelector(".govuk-js-character-count");
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Matches(new Regex($"\\b{countMessage!.Id}\\b"), textarea!.Attributes[AriaDescribedBy]?.Value ?? "");
    }

    [Fact]
    public async void RendersWithCustomClasses()
    {
        var response = await Navigate("/CharacterCount/CustomClassesOnCountMessage");
        var countMessage = response.QuerySelector(".govuk-character-count__message");

        Assert.Contains("app-custom-count-message", countMessage!.ClassList);
    }
}
