﻿using MicroservicesPractice.Web.Exceptions;
using MicroservicesPractice.Web.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace MicroservicesPractice.Web.Handler
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetTokenAsync());

            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode == HttpStatusCode.Unauthorized) throw new UnAuthorizeException();

            return response;
        }
    }
}
