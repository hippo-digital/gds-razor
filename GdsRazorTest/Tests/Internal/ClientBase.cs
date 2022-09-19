using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using OpenQA.Selenium;
using Selenium.Axe;
using Xunit;

namespace GdsRazorTest.Tests.Internal;

[CollectionDefinition("GDS")]
public class GdsCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>, ICollectionFixture<SeleniumBase>
{
}

[Collection("GDS")]
public abstract class ClientBase<TStartup> where TStartup : class
{
    private readonly IWebDriver? _driver;
    protected readonly HttpClient Http;
    protected readonly IBrowsingContext Context;
    protected readonly string BaseExternalAddress;
    protected readonly string BaseInternalAddress;

    protected ClientBase(CustomWebApplicationFactory<TStartup> factory, IWebDriver? driver = null)
    {
        _driver = driver;
        Http = factory.Http;
        BaseExternalAddress = factory.GetServerAddress();
        BaseInternalAddress = CustomWebApplicationFactory<TStartup>.BaseAddress;
        //.WithCss().WithJs().WithRenderDevice()
        Context = BrowsingContext.New(Configuration.Default.With(new HttpClientRequester(factory.Http)).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true, IsNavigationDisabled = false }));
    }

    public Task<IHtmlDocument> Follow(IElement element)
    {
        switch (element)
        {
            case IHtmlLinkElement link:
                return Navigate(link.Href!);
            case IHtmlAnchorElement a:
                return Navigate(a.Href);
            default:
                throw new Exception($"Unable to follow a {element.GetType()}");
        }
    }

    protected async Task<IHtmlDocument> Navigate(string uri)
    {
        var document = await Context.OpenAsync(BaseInternalAddress + uri, CancellationToken.None);
        return (IHtmlDocument) document;
    }

    protected AxeResult AxeResults(string type)
    {
        _driver?.Navigate().GoToUrl(BaseExternalAddress + $"/{type}/Axe");
        return new AxeBuilder(_driver).DisableRules("region", "skip-link").Analyze();
    }
}
