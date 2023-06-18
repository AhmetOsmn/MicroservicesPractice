using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using MicroservicesPractice.Shared.Helpers;
using MicroservicesPractice.Web.Models;
using MicroservicesPractice.Web.Services.Abstract;
using Microsoft.Extensions.Options;

namespace MicroservicesPractice.Web.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly HttpClient _httpClient;
        private readonly ClientAccessTokenParameters _clientAccessTokenParamters;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private const string _tokenKey = "WebClientToken";

        public ClientCredentialTokenService(
            IOptions<ServiceApiSettings> serviceApiSettings,
            IOptions<ClientSettings> clientSettings,
            IClientAccessTokenCache clientAccessTokenCache,
            HttpClient httpClient)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _clientSettings = clientSettings.Value;
            _clientAccessTokenCache = clientAccessTokenCache;
            _httpClient = httpClient;
            _clientAccessTokenParamters = new ClientAccessTokenParameters { Resource = "ClientCredentialTokenService" };
        }

        public async Task<string> GetTokenAsync()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync(_tokenKey, _clientAccessTokenParamters);
            if (currentToken != null) { return currentToken.AccessToken; }

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityBaseUri,
                Policy = new DiscoveryPolicy { RequireHttps = false }
            });

            ObjectHelper.ObjectNullCheck(discovery, nameof(discovery));

            if (discovery.IsError) throw discovery.Exception!;

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.WebClient.ClientId,
                ClientSecret = _clientSettings.WebClient.ClientSecret,
                Address = discovery.TokenEndpoint
            };

            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            ObjectHelper.ObjectNullCheck(newToken, nameof(newToken));

            if (newToken.IsError) throw newToken.Exception!;

            await _clientAccessTokenCache.SetAsync(_tokenKey, newToken.AccessToken, newToken.ExpiresIn, _clientAccessTokenParamters);

            return newToken.AccessToken;
        }
    }
}
