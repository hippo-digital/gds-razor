using System.Net.Http.Headers;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace GdsRazorTest.Tests.Internal;

public abstract class ClientBase<TStartup> where TStartup : class
{
    protected readonly HttpClient Http;

    protected ClientBase(WebApplicationFactory<TStartup> factory)
    {
        Http = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(Configure);
        }).CreateClient(new WebApplicationFactoryClientOptions
        {
            BaseAddress = new Uri("https://localhost"),
            HandleCookies = false
        });
            
        Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
    }

    protected abstract void Configure(IServiceCollection services);

    public Task<IHtmlDocument> Follow(IElement element)
    {
        switch (element)
        {
            case IHtmlLinkElement link:
                return Http.GetAsync(link.Href).GetDocumentAsync();
            case IHtmlAnchorElement a:
                return Http.GetAsync(a.Href).GetDocumentAsync();
            default:
                throw new Exception($"Unable to follow a {element.GetType()}");
        }
    }
        
    public async Task<IHtmlDocument> Navigate(string uri, Action<HttpResponseMessage>? responseValidation = null)
    {
        var response = await Http.GetAsync(uri);
        responseValidation?.Invoke(response);
        return await response.GetDocumentAsync();
    }

    public async Task<HttpResponseMessage> Get(string uri)
    {
        return await Http.GetAsync(uri);
    }
        
    public async Task<string> GetString(string uri)
    {
        return await Http.GetStringAsync(uri);
    }

        
    public async Task<HttpResponseMessage> Send(string uri, Action<HttpRequestMessage>? cfg = null)
    {
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(Http.BaseAddress?.AbsoluteUri.TrimEnd('/') + "/" + uri.TrimStart('/')),
            Method = HttpMethod.Get
        };
            
        cfg?.Invoke(request);
            
        return await Http.SendAsync(request);
    }
        
        
    public async Task<IHtmlDocument> SubmitForm(
        IElement formElement,
        IElement submitButtonElement,
        Action<IHtmlFormElement>? cfg = null)
    {
        var form = Assert.IsAssignableFrom<IHtmlFormElement>(formElement);
        var submitButton = Assert.IsAssignableFrom<IHtmlButtonElement>(submitButtonElement);
            
        cfg?.Invoke(form);
           
        var submit = form.GetSubmission(submitButton);
            
        var target = (Uri)submit.Target;
        if (!string.IsNullOrWhiteSpace(submitButton.Form.Action))
        {
            var formAction = submitButton.Form.Action;
            target = new Uri(formAction, UriKind.RelativeOrAbsolute);
        }
            
        var submission = new HttpRequestMessage(new HttpMethod(submit.Method.ToString()), target)
        {
            Content = new StreamContent(submit.Body)
        };
            
        foreach (var header in submit.Headers)
        {
            submission.Headers.TryAddWithoutValidation(header.Key, header.Value);
            submission.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
            
        return await Http.SendAsync(submission).GetDocumentAsync();
            
    }
}