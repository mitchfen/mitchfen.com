namespace MitchfenSite;

public class AddHeadersDelegatingHandler() : DelegatingHandler(new HttpClientHandler())
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Frame-Options", "SAMEORIGIN");
        request.Headers.Add("Content-Security-Policy", "default-src 'self'");
        request.Headers.Add("Permissions-Policy", "geolocation=(), microphone=(), camera=()");

        return base.SendAsync(request, cancellationToken);
    }
}