using Newtonsoft.Json;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class Attribute
    {
        public Attribute()
        {
            SubAttributes = new List<Attribute>();
            CanonicalValues = new List<string>();
            ReferenceTypes = new List<string>();
        }

        /// <summary>
        /// The attribute's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The attribute's data type.  Valid values are "string",
        /// "boolean", "decimal", "integer", "dateTime", "reference", and
        /// "complex".  When an attribute is of type "complex", there
        /// SHOULD be a corresponding schema attribute "subAttributes"
        /// defined, listing the sub-attributes of the attribute.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// When an attribute is of type "complex",
        /// "subAttributes" defines a set of sub-attributes.
        /// "subAttributes" has the same schema sub-attributes as
        /// "attributes".
        /// </summary>
        [JsonProperty("subAttributes")]
        public List<Attribute> SubAttributes { get; set; }

        /// <summary>
        /// A Boolean value indicating the attribute's plurality.
        /// </summary>
        [JsonProperty("multiValued")]
        public bool MultiValued { get; set; }

        /// <summary>
        /// The schema's human-readable description.  When applicable, service
        /// providers MUST specify the description.OPTIONAL.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A Boolean value that specifies whether or not the
        /// attribute is required.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        /// <summary>
        /// A collection of suggested canonical values that
        /// MAY be used(e.g., "work" and "home").  In some cases, service
        /// providers MAY choose to ignore unsupported values.OPTIONAL.
        /// </summary>
        [JsonProperty("canonicalValues")]
        public List<string> CanonicalValues { get; set; }

        /// <summary>
        /// A Boolean value that specifies whether or not a string
        /// attribute is case sensitive.The server SHALL use case
        /// sensitivity when evaluating filters.For attributes that are
        /// case exact, the server SHALL preserve case for any value
        /// submitted.If the attribute is case insensitive, the server
        /// MAY alter case for a submitted value.Case sensitivity also
        /// impacts how attribute values MAY be compared against filter
        /// values (see Section 3.4.2.2 of[RFC7644]).
        /// </summary>
        [JsonProperty("caseExact")]
        public bool CaseExact { get; set; }

        /// <summary>
        /// A single keyword indicating the circumstances under
        /// which the value of the attribute can be(re)defined:
        /// 
        /// readOnly The attribute SHALL NOT be modified.
        /// 
        /// readWrite The attribute MAY be updated and read at any time.
        ///     This is the default value.
        /// 
        /// immutable The attribute MAY be defined at resource creation
        ///     (e.g., POST) or at record replacement via a request(e.g., a
        ///     PUT).  The attribute SHALL NOT be updated.
        /// 
        /// writeOnly  The attribute MAY be updated at any time.  Attribute
        ///     values SHALL NOT be returned (e.g., because the value is a
        ///     stored hash).  Note: An attribute with a mutability of
        ///     "writeOnly" usually also has a returned setting of "never".
        /// </summary>
        [JsonProperty("mutability")]
        public string Mutability { get; set; }

        /// <summary>
        /// A single keyword that indicates when an attribute and
        /// associated values are returned in response to a GET request or
        /// in response to a PUT, POST, or PATCH request.Valid keywords
        /// are as follows:
        /// 
        /// always The attribute is always returned, regardless of the
        ///    contents of the "attributes" parameter.For example, "id"
        ///    is always returned to identify a SCIM resource.
        ///    
        /// never The attribute is never returned.  This may occur because
        ///    the original attribute value (e.g., a hashed value) is not
        ///    retained by the service provider.A service provider MAY
        ///    allow attributes to be used in a search filter.
        ///    
        /// default  The attribute is returned by default in all SCIM
        ///    operation responses where attribute values are returned.If
        ///    the GET request "attributes" parameter is specified,
        ///    attribute values are only returned if the attribute is named
        ///    in the "attributes" parameter.DEFAULT.
        ///    
        /// request The attribute is returned in response to any PUT,
        ///    POST, or PATCH operations if the attribute was specified by
        ///    the client (for example, the attribute was modified).  The
        ///    attribute is returned in a SCIM query operation only if
        ///    specified in the "attributes" parameter.
        /// </summary>
        [JsonProperty("returned")]
        public string Returned { get; set; }

        /// <summary>
        /// A single keyword value that specifies how the service
        /// provider enforces uniqueness of attribute values.A server MAY
        /// reject an invalid value based on uniqueness by returning HTTP
        /// response code 400 (Bad Request).  A client MAY enforce
        /// uniqueness on the client side to a greater degree than the
        /// service provider enforces.  For example, a client could make a
        /// value unique while the server has uniqueness of "none".  Valid
        /// keywords are as follows:
        ///
        /// none The values are not intended to be unique in any way.
        ///   DEFAULT.
        ///   
        /// server The value SHOULD be unique within the context of the
        ///   current SCIM endpoint (or tenancy) and MAY be globally
        ///   unique (e.g., a "username", email address, or other
        ///   server-generated key or counter).  No two resources on the
        ///   same server SHOULD possess the same value.
        ///   
        /// global  The value SHOULD be globally unique (e.g., an email
        ///   address, a GUID, or other value).  No two resources on any
        ///   server SHOULD possess the same value.
        /// </summary>
        [JsonProperty("uniqueness")]
        public string Uniqueness { get; set; }

        /// <summary>
        /// A multi-valued array of JSON strings that indicate
        /// the SCIM resource types that may be referenced.
        /// 
        /// This attribute is only applicable for attributes that are of
        /// type "reference" (Section 2.3.7).
        /// </summary>
        [JsonProperty("referenceTypes")]
        public List<string> ReferenceTypes { get; set; }
    }
}
