using BaseMauiApp.Result;
using BaseMauiApp.Types;
using RestSharp;
using RestSharp.Authenticators;

namespace BaseMauiApp.Builder;

public class RestBuilder
{
    private readonly RestClientOptions _options;
    private readonly RestRequest _request = new();

    public RestBuilder(string? host = "", bool ignoreInvalidCert
        = false)
    {
        if (string.IsNullOrEmpty(host))
        {
            if (string.IsNullOrEmpty(RestManager.Host))
                throw new ArgumentNullException(nameof(host), "Host is null");
            host = RestManager.Host;
        }

        RestManager.Host = host;

        _options = new RestClientOptions($"https://{host}")
        {
            FollowRedirects = true,
            AllowMultipleDefaultParametersWithSameName = true,
            ThrowOnDeserializationError = true,
            ThrowOnAnyError = true,
            FailOnDeserializationError = true
        };
        if (ignoreInvalidCert)
            _options.RemoteCertificateValidationCallback = (_, _, _, _) => true;
        if (!string.IsNullOrEmpty(RestManager.Token))
            _options.Authenticator = new JwtAuthenticator(RestManager.Token);
    }

    public RestBuilder WithToken(string token)
    {
        RestManager.Token = token;
        _options.Authenticator = new JwtAuthenticator(token);
        return this;
    }

    public RestBuilder WithResource(string path, RestPathType type = RestPathType.Global)
    {
        path = type switch
        {
            RestPathType.Global => $"Global/{path}",
            RestPathType.Client => $"Client/{path}",
            RestPathType.Admin => $"Admin/{path}",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
        _request.Resource = path;
        return this;
    }
    public RestBuilder WithMethod(Method method)
    {
        _request.Method = method;
        return this;
    }

    public RestBuilder WithBody<TBody>(TBody body) where TBody : class, new()
    {
        _request.AddJsonBody(body);
        return this;
    }
    
    public async Task<BaseResult<TResponse>> Request<TResponse>() where TResponse : class, new()
    {
        try
        {
            var client = new RestClient(_options);
            var response = await client.ExecuteAsync<BaseResult<TResponse>>(_request);
            if (response is null)
                throw new Exception("Response is null");
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ErrorMessage ?? response.StatusDescription);
            if (response.Data is not {} result)
                throw new Exception("Response data is null");
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    
    
}

public static class RestManager
{
    public static string Host { get; set; }
    public static string Token { get; set; }
}