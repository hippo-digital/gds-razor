using System.Net;
using AngleSharp.Dom;
using AngleSharp.Io;

namespace Hippo.GdsRazor.Test.Components.Internal;

using HttpMethod = System.Net.Http.HttpMethod;

/// <summary>
/// An HTTP requester based on <see cref="HttpClient"/>.
/// </summary>
public class HttpClientRequester : BaseRequester
{
    #region Fields

    private readonly HttpClient _client;

    #endregion

    #region ctor

    /// <summary>
    /// Creates a new HTTP client request with a new HttpClient instance.
    /// </summary>
    public HttpClientRequester()
        : this(new HttpClient())
    {
    }

    /// <summary>
    /// Creates a new HTTP client request.
    /// </summary>
    /// <param name="client">The HTTP client to use for requests.</param>
    public HttpClientRequester(HttpClient client)
    {
        _client = client;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the used HttpClient for further manipulation.
    /// </summary>
    public HttpClient Client => _client;

    #endregion

    #region Methods

    /// <summary>
    /// Checks if the given protocol is supported.
    /// </summary>
    /// <param name="protocol">
    /// The protocol to check for, e.g., http.
    /// </param>
    /// <returns>
    /// True if the protocol is supported, otherwise false.
    /// </returns>
    public override Boolean SupportsProtocol(String protocol) =>
        protocol.Equals(ProtocolNames.Http, StringComparison.OrdinalIgnoreCase) ||
        protocol.Equals(ProtocolNames.Https, StringComparison.OrdinalIgnoreCase);


    /// <summary>
    /// Performs an asynchronous request that can be cancelled.
    /// </summary>
    /// <param name="request">The options to consider.</param>
    /// <param name="cancel">The token for cancelling the task.</param>
    /// <returns>
    /// The task that will eventually give the response data.
    /// </returns>
    protected override async Task<IResponse?> PerformRequestAsync(Request request, CancellationToken cancel)
    {
        // create the request message
        var method = new HttpMethod(request.Method.ToString().ToUpperInvariant());
        var requestMessage = new HttpRequestMessage(method, request.Address);
        var contentHeaders = request.Headers
            .Where(header => !requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value))
            .Select(header => (header.Key, header.Value)).ToList();

        // set up the content
        if (request.Content != null && method != HttpMethod.Get && method != HttpMethod.Head)
        {
            requestMessage.Content = new StreamContent(request.Content);

            foreach (var header in contentHeaders)
            {
                requestMessage.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        try
        {
            // execute the request
            var responseMessage = await _client.SendAsync(requestMessage, cancel).ConfigureAwait(false);

            // convert the response
            var response = new DefaultResponse
            {
                Headers = responseMessage.Headers.ToDictionary(p => p.Key, p => String.Join(", ", p.Value)),
                Address = Url.Convert(responseMessage.RequestMessage!.RequestUri!),
                StatusCode = responseMessage.StatusCode
            };

            // get the anticipated content
            var content = responseMessage.Content;

            response.Content = await content.ReadAsStreamAsync(cancel).ConfigureAwait(false);

            foreach (var pair in content.Headers)
            {
                response.Headers[pair.Key] = string.Join(", ", pair.Value);
            }

            if (IsRedirected(response) && !response.Headers.ContainsKey(HeaderNames.SetCookie))
            {
                response.Headers[HeaderNames.SetCookie] = string.Empty;
            }

            return response;
        }
        catch (Exception)
        {
            // create a response to avoid failing (#28)
            return new DefaultResponse
            {
                Address = Url.Convert(request.Address),
                StatusCode = 0
            };
        }
    }

    private static Boolean IsRedirected(IResponse response)
    {
        var status = response.StatusCode;

        return status is HttpStatusCode.Redirect or HttpStatusCode.RedirectKeepVerb or HttpStatusCode.RedirectMethod or HttpStatusCode.TemporaryRedirect or
            HttpStatusCode.MovedPermanently or HttpStatusCode.MultipleChoices;
    }

    #endregion
}
