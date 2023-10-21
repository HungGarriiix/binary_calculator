using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot_api_dotnet
{
    public struct ConfigJSON
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }
}
