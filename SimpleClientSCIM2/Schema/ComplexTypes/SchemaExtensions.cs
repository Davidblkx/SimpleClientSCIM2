using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class SchemaExtensions
    {
        /// <summary>
        /// The URI of an extended schema, e.g., "urn:edu:2.0:Staff".
        /// This MUST be equal to the "id" attribute of a "Schema"
        /// resource.REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("schema")]
        public string Schema { get; set; }

        /// <summary>
        /// A Boolean value that specifies whether or not the schema
        /// extension is required for the resource type.If true, a
        /// resource of this type MUST include this schema extension and
        /// also include any attributes declared as required in this schema
        /// extension.  If false, a resource of this type MAY omit this
        /// schema extension.  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("required")]
        public bool Required { get; set; }
    }
}
