using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class MultiValue
    {
        public MultiValue()
        {
            Primary = false;
        }

        /// <summary>
        /// The attribute's significant value, e.g., email address, phone
        /// number.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// A label indicating the attribute's function, e.g., "work" or
        /// "home".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// A human-readable name, primarily used for display purposes and
        /// having a mutability of "immutable".
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        /// <summary>
        /// A Boolean value indicating the 'primary' or preferred attribute
        /// value for this attribute, e.g., the preferred mailing address or
        /// the primary email address.The primary attribute value "true"
        /// MUST appear no more than once.If not specified, the value of
        /// "primary" SHALL be assumed to be "false".
        /// </summary>
        [JsonProperty("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// The reference URI of a target resource, if the attribute is a
        /// reference.URIs are canonicalized per Section 6.2 of[RFC3986].
        /// While the representation of a resource may vary in different SCIM
        /// protocol API versions(see Section 3.13 of[RFC7644]), URIs for
        /// SCIM resources with an API version SHALL be considered comparable
        /// to URIs without a version or with a different version.For
        /// example, "https://example.com/Users/12345" is equivalent to
        /// "https://example.com/v2/Users/12345".
        /// </summary>
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }
}
