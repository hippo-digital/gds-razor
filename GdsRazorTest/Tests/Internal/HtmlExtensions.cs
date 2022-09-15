using System.Net.Http.Headers;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using AngleSharp.Io.Dom;

namespace GdsRazorTest.Tests.Internal;

public static class HtmlExtensions
{
    public static IHtmlFormElement SetFormValues(this IHtmlFormElement form, IDictionary<string,string> formValues)
    {
        foreach (var kvp in formValues)
        {
            if (form[kvp.Key] is IHtmlInputElement element)
            {
                if (element.Type == "radio")
                {
                    element.IsChecked = true;
                }

                element.Value = kvp.Value;
            }
        }

        return form;
    }
    
    public static IHtmlFormElement AddFiles(this IHtmlFormElement form, string inputName, params IFile[] files)
    {
        if (form[inputName] is IHtmlInputElement fileInput)
        {
            foreach (var file in files)
            {
                fileInput.Files.Add(file);
            }
        }

        return form;
    }
    
    public static async Task<IHtmlDocument> GetDocumentAsync(this HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var document = await BrowsingContext.New(Configuration.Default/*.WithCss()*/).OpenAsync(ResponseFactory, CancellationToken.None);
        return (IHtmlDocument) document;

        void ResponseFactory(VirtualResponse htmlResponse)
        {
            htmlResponse
                .Address(response.RequestMessage?.RequestUri)
                .Status(response.StatusCode);

            MapHeaders(response.Headers);
            MapHeaders(response.Content.Headers);

            htmlResponse.Content(content);

            void MapHeaders(HttpHeaders headers)
            {
                foreach (var header in headers)
                {
                    foreach (var value in header.Value)
                    {
                        htmlResponse.Header(header.Key, value);
                    }
                }
            }
        }
    }

    public static async Task<IHtmlDocument> GetDocumentAsync(this Task<HttpResponseMessage> responseMessage)
    {
        var response = await responseMessage;
        return await response.GetDocumentAsync();
    }

    public static IEnumerable<(string, string)> GetBreadcrumbs(this IHtmlDocument doc)
    {
        return doc.GetElementsByClassName("govuk-breadcrumbs__link").Select(l =>
        {
            var c = (IHtmlAnchorElement) l;
            return (c.TextContent, c.Href);
        });
    }
    
    public static (string Text, string Href) GetBackLink(this IHtmlDocument doc)
    {
        return doc.GetElementsByClassName("govuk-back-link").Select(l =>
        {
            var c = (IHtmlAnchorElement) l;
            return (c.TextContent, c.Href);
        }).FirstOrDefault();
    }
    
    public static IEnumerable<T> FindMainContentElements<T>(this IHtmlDocument doc)
    {
        return doc.GetElementById("main-content").Descendents().OfType<T>();
    }
    
}