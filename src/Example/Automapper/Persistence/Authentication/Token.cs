using System;
using Newtonsoft.Json;
namespace Persistence.Authentication
{
	public class Token
	{
		[JsonProperty(PropertyName="access_token")]
		public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        public bool IsValidAndNotExpiring
        {
            get
            {
                if(!string.IsNullOrEmpty(AccessToken))
                {
                    return ExpiresAt > DateTime.UtcNow.AddSeconds(30.0);
                }
                return false;
            }
        }

    }
}

