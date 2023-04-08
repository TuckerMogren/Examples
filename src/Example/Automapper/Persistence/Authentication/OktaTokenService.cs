using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Azure.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Persistence.Authentication
{
	public class OktaTokenService : ITokenService
	{
        private Token _token = new Token();
		private readonly Uri _tokenURL;
		private readonly HttpClient _httpClient;
		private readonly ILogger _logger;


        public OktaTokenService(Uri tokenURL, HttpClient httpClient, ILogger logger)
		{
			_tokenURL = tokenURL;
			_httpClient = httpClient;
			_logger = logger;
		}


		public async Task<Token> GetToken (string username, string password)
		{
			if(_token.IsValidAndNotExpiring)
			{
				return _token;
			}
			_token = await GetNewAccessToken(username, password);

			return _token;
		}

        private async Task<Token> GetNewAccessToken(string username, string password)
        {
            _logger.LogDebug("Fetching new Access Token");

            byte[] bytes = Encoding.UTF8.GetBytes(username + ":" + password);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));

            Dictionary<string, string> nameValueCollection = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", "access_token"}
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _tokenURL)
            {
                Content = new FormUrlEncodedContent(nameValueCollection)
            };

            HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request);


            if (httpResponseMessage.IsSuccessStatusCode)
            {
                Token token = JsonConvert.DeserializeObject<Token>(await httpResponseMessage.Content.ReadAsStringAsync());

                token.ExpiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);

                return token;

            }

            _logger.LogError("Unable to retrieve access token from Okta.");

            throw new AuthenticationException("Unable to retrieve access token from Okta");
        }

    }
}

