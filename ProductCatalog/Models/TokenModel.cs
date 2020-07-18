using Newtonsoft.Json;

namespace ProductCatalog.Models
{
    public class TokenModel
    {
        [JsonProperty("access_token")]
        public string Token { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
    }
}
