using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class AuthenticationScheme
    {
        /// <summary>
        /// The authentication scheme.  This specification defines the
        /// values "oauth", "oauth2", "oauthbearertoken", "httpbasic", and
        /// "httpdigest".  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The common authentication scheme name, e.g., HTTP Basic.
        /// REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A description of the authentication scheme.
        /// REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// An HTTP-addressable URL pointing to the authentication
        /// scheme's specification.  OPTIONAL.
        /// </summary>
        [JsonProperty("specUri")]
        public string SpecUri { get; set; }

        /// <summary>
        /// An HTTP-addressable URL pointing to the
        /// authentication scheme's usage documentation.  OPTIONAL.
        /// </summary>
        [JsonRequired]
        [JsonProperty("documentationUri")]
        public string DocumentationUri { get; set; }
    }
}
