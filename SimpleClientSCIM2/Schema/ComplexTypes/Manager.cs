using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class Manager
    {
        /// <summary>
        /// The "id" of the SCIM resource representing the user's
        /// manager.RECOMMENDED.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// A human-readable name, primarily used for display purposes and
        /// having a mutability of "immutable".
        /// </summary>
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The URI of the SCIM resource representing the User's
        /// manager.RECOMMENDED.
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }
}
