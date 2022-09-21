using AngleSharp;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using AutoFixture;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;
using OpenQA.Selenium;
using Selenium.Axe;
using Xunit;

namespace Hippo.GdsRazor.Test.Tests.Internal;

[CollectionDefinition("GDS")]
public class GdsCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>, ICollectionFixture<SeleniumBase>
{
    public static (string, GdsAttributes?) Model = ("", null);
}

public class GdsAutoDataAttribute : AutoDataAttribute
{
    public GdsAutoDataAttribute()
        : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new TypeRelay(typeof(GdsContent), typeof(GdsPlain)));
            fixture.Customizations.Add(new TypeRelay(typeof(CheckboxesModel.IItemModel), typeof(CheckboxesModel.ItemModel)));
            return fixture;
        }) { }
}

[Collection("GDS")]
public abstract class ClientBase<TStartup> where TStartup : class
{
    protected const string AriaDescribedBy = "aria-describedby";
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

    protected async Task<IHtmlDocument> Navigate(string controller, string action)
    {
        var document = await Context.OpenAsync($"{BaseInternalAddress}/{controller}/{action}", CancellationToken.None);
        return (IHtmlDocument) document;
    }

    protected AxeResult AxeResults(string type, string action = "Axe")
    {
        _driver?.Navigate().GoToUrl(BaseExternalAddress + $"/{type}/{action}");
        return new AxeBuilder(_driver).DisableRules("region", "skip-link").Analyze();
    }

    protected async Task<string> AutoFixtureResults<T>(string type, T model) where T : GdsAttributes
    {
        GdsCollection.Model = ($"Gds{type}", model);
        var document = await Context.OpenAsync($"{BaseInternalAddress}/Custom", CancellationToken.None);
        return ((IHtmlDocument) document).ToHtml();
    }
}
