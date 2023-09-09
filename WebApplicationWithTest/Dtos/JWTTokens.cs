using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplicationWithTest.Dtos
{
    public class JWTTokens
    {
        [JsonPropertyName("accesstoken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshtoken")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires")]
        public DateTime? Expires { get; set; }
    }
}
