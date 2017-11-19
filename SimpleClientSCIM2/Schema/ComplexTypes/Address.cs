using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class Address
    {
        /// <summary>
        /// The full mailing address, formatted for display or use
        /// with a mailing label.This attribute MAY contain newlines.
        /// </summary>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// The full street address component, which may
        /// include house number, street name, P.O.box, and multi-line
        /// extended street address information.This attribute MAY
        /// contain newlines.
        /// </summary>
        [JsonProperty("streetAddress")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// The city or locality component.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// The state or region component.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The zip code or postal code component.
        /// </summary>
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The country name component.  When specified, the value
        /// MUST be in ISO 3166-1 "alpha-2" code format[ISO3166]; e.g.,
        /// the United States and Sweden are "US" and "SE", respectively.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
