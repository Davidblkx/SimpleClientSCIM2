using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.ComplexTypes;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema
{
    /// <summary>
    /// Unless otherwise specified, all schema
    /// attributes are case insensitive.These resources have a "schemas"
    /// attribute with the following schema URI:
    /// urn:ietf:params:scim:schemas:core:2.0:Schema
    /// Unlike other core resources, the "Schema" resource MAY contain a
    /// complex object within a sub-attribute, and all attributes are
    /// REQUIRED unless otherwise specified.
    /// </summary>
    public class SchemaDefinition : Resource
    {
        public SchemaDefinition()
        {
            Attributes = new List<Attribute>();
        }

        /// <summary>
        /// The unique URI of the schema.  When applicable, service providers
        /// MUST specify the URI, e.g.,
        /// "urn:ietf:params:scim:schemas:core:2.0:User".  Unlike most other
        /// schemas, which use some sort of Globally Unique Identifier(GUID)
        /// for the "id", the schema "id" is a URI so that it can be
        /// registered and is portable between different service providers and
        /// clients.REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        new public string Id { get; set; }

        /// <summary>
        /// The schema's human-readable name.  When applicable, service
        /// providers MUST specify the name, e.g., "User" or "Group".
        /// OPTIONAL.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The schema's human-readable description.  When applicable, service
        /// providers MUST specify the description.OPTIONAL.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// A complex type that defines service provider attributes and their
        /// qualities
        /// </summary>
        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        public static SchemaDefinition Create()
        {
            return new SchemaDefinition
            {
                Schemas = new List<string> { "urn:ietf:params:scim:schemas:core:2.0:Schema" }
            };
        }
    }
}
