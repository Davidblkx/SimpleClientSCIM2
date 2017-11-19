using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.ComplexTypes;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema
{
    /// <summary>
    /// The "ResourceType" schema specifies the metadata about a resource
    /// type.Resource type resources are READ-ONLY and identified using the
    /// following schema URI:
    /// "urn:ietf:params:scim:schemas:core:2.0:ResourceType".  Unlike other
    /// core resources, all attributes are REQUIRED unless otherwise
    /// specified.The "id" attribute is not required for the resource type
    /// resource.
    /// </summary>
    public class ResourceType : Resource
    {

        /// <summary>
        /// The resource type's server unique id.  This is often the same
        /// value as the "name" attribute.OPTIONAL.
          /// </summary>
        [JsonProperty("id")]
        new public string Id { get; set; }

        /// <summary>
        /// The resource type name.  When applicable, service providers MUST
        /// specify the name, e.g., "User" or "Group".  This name is
        /// referenced by the "meta.resourceType" attribute in all resources.
        /// REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The resource type's human-readable description.  When applicable,
        /// service providers MUST specify the description.OPTIONAL.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The resource type's HTTP-addressable endpoint relative to the Base
        /// URL of the service provider, e.g., "Users".  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("endpoint")]
        public string Endpoint { get; set; }

        /// <summary>
        /// The resource type's primary/base schema URI, e.g.,
        /// "urn:ietf:params:scim:schemas:core:2.0:User".  This MUST be equal
        /// to the "id" attribute of the associated "Schema" resource.
        /// REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("schema")]
        public string Schema { get; set; }

        /// <summary>
        /// A list of URIs of the resource type's schema extensions.
        /// </summary>
        [JsonProperty("schemaExtensions")]
        public List<SchemaExtensions> SchemaExtensions { get; set; }

        public static ResourceType Create()
        {
            return new ResourceType
            {
                Schemas = new List<string> { "urn:ietf:params:scim:schemas:core:2.0:ResourceType" }
            };
        }
    }
}
