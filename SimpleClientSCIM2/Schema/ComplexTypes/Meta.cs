using Newtonsoft.Json;
using System;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class Meta
    {
        /// <summary>
        /// The name of the resource type of the resource.  This
        /// attribute has a mutability of "readOnly" and "caseExact" as
        /// "true".
        /// </summary>
        [JsonProperty("resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// The "DateTime" that the resource was added to the service
        /// provider.This attribute MUST be a DateTime.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// The most recent DateTime that the details of this
        /// resource were updated at the service provider.If this
        /// resource has never been modified since its initial creation,
        /// the value MUST be the same as the value of "created".
        /// </summary>
        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// The URI of the resource being returned.  This value MUST
        /// be the same as the "Content-Location" HTTP response header(see
        /// Section 3.1.4.2 of[RFC7231]).
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// The version of the resource being returned.  This value
        /// must be the same as the entity-tag(ETag) HTTP response header
        /// (see Sections 2.1 and 2.3 of[RFC7232]).  This attribute has
        /// "caseExact" as "true".  Service provider support for this
        /// attribute is optional and subject to the service provider's
        /// support for versioning(see Section 3.14 of[RFC7644]).  If a
        /// service provider provides "version" (entity-tag) for a
        /// representation and the generation of that entity-tag does not
        /// satisfy all of the characteristics of a strong validator(see
        /// Section 2.1 of[RFC7232]), then the origin server MUST mark the
        /// "version" (entity-tag) as weak by prefixing its opaque value
        /// with "W/" (case sensitive).
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
