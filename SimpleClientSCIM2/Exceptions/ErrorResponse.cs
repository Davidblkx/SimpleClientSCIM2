using Newtonsoft.Json;

namespace SimpleClientSCIM2.Exceptions
{
    public class ErrorResponse
    {
        /// <summary>
        /// The HTTP status code (see Section 6 of [RFC7231]) expressed as a
        /// JSON string.  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// A SCIM detail error keyword.
        /// </summary>
        [JsonProperty("scimType")]
        public string SCIMType { get; set; }

        /// <summary>
        /// A detailed human-readable message.  OPTIONAL.
        /// </summary>
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
