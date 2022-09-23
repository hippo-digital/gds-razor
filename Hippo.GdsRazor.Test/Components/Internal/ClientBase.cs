using System.Text.RegularExpressions;
using AngleSharp;
using AngleSharp.Dom;
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

namespace Hippo.GdsRazor.Test.Components.Internal;

[CollectionDefinition("GDS")]
public class GdsCollection : ICollectionFixture<CustomWebApplicationFactory<Startup>>, ICollectionFixture<SeleniumBase>
{
    internal static readonly Regex AfterTagWhitespace = new("(?:([^b]>)\\s+|\\s+(<[^b]))", RegexOptions.Compiled);
    internal static (string, GdsAttributes?) Model = ("", null);
}

public class GdsAutoDataAttribute : AutoDataAttribute
{
    public GdsAutoDataAttribute()
        : base(() =>
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new TypeRelay(typeof(GdsContent), typeof(GdsPlain)));
            fixture.Customizations.Add(new TypeRelay(typeof(CheckboxesModel.IItemModel), typeof(CheckboxesModel.ItemModel)));
            fixture.Customizations.Add(new TypeRelay(typeof(RadiosModel.IItemModel), typeof(RadiosModel.ItemModel)));
            fixture.Customizations.Add(new TypeRelay(typeof(PaginationModel.IItemModel), typeof(PaginationModel.ItemModel)));
            return fixture;
        }) { }
}

[Collection("GDS")]
public abstract class ClientBase<TStartup> where TStartup : class
{
    protected const string AriaDescribedBy = "aria-describedby";
    private readonly IWebDriver? _driver;
    private readonly IBrowsingContext _context;
    private readonly string _baseExternalAddress;
    private readonly string _baseInternalAddress;

    protected ClientBase(CustomWebApplicationFactory<TStartup> factory, IWebDriver? driver = null)
    {
        _driver = driver;
        _baseExternalAddress = factory.GetServerAddress();
        _baseInternalAddress = CustomWebApplicationFactory<TStartup>.BaseAddress;
        //.WithCss().WithJs().WithRenderDevice()
        _context = BrowsingContext.New(Configuration.Default.With(new HttpClientRequester(factory.Http)).WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = true, IsNavigationDisabled = false }));
    }

    protected async Task<IHtmlDocument> Navigate(string controller, string action)
    {
        var document = await _context.OpenAsync($"{_baseInternalAddress}/{controller}/{action}", CancellationToken.None);
        return (IHtmlDocument) document;
    }

    protected AxeResult AxeResults(string type, string action = "Axe")
    {
        _driver?.Navigate().GoToUrl(_baseExternalAddress + $"/{type}/{action}");
        return new AxeBuilder(_driver).DisableRules("region", "skip-link").Analyze();
    }

    protected async Task<string> AutoFixtureResults<T>(string type, T model) where T : GdsAttributes
    {
        GdsCollection.Model = ($"Gds{type}", model);
        var document = await _context.OpenAsync($"{_baseInternalAddress}/Custom", CancellationToken.None);
        return ((IHtmlDocument) document).ToHtml();
    }

    /// <summary>
    /// Get the raw HTML representation of a component, and remove any other
    /// child elements that do not match the component.
    /// Relies on B.E.M naming ensuring that child components relating to a component
    /// are namespaced.
    /// </summary>
    /// <param name="parentNode">the parent element</param>
    /// <param name="className">the top level class 'Block' in B.E.M terminology</param>
    /// <returns>HTML</returns>
    protected string HtmlWithClassName(IParentNode parentNode, string className)
    {
        return string.Join("", parentNode.QuerySelectorAll($".{className}").Select(outerElement =>
        {
            foreach (var element in outerElement.QuerySelectorAll($"[class]:not([class^={className}])")) element.Remove();
            return GdsCollection.AfterTagWhitespace.Replace(outerElement.OuterHtml.ReplaceLineEndings(""), "$1$2");
        }));
    }
}
