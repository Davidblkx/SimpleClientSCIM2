using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.ComplexTypes;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema
{
    /// <summary>
    /// SCIM provides a schema for representing the service provider's
    /// configuration, identified using the following schema URI:
    /// "urn:ietf:params:scim:schemas:core:2.0:ServiceProviderConfig".
    /// The service provider configuration resource enables a service
    /// provider to discover SCIM specification features in a standardized
    /// form as well as provide additional implementation details to clients.
    /// All attributes have a mutability of "readOnly".  Unlike other core
    /// resources, the "id" attribute is not required for the service
    /// provider configuration resource.
    /// </summary>
    public class ServiceProvider : Resource
    {
        public ServiceProvider()
        {
            AuthenticationSchemes = new List<AuthenticationScheme>();
            Patch = new Operation();
            Bulk = new Operation();
            Filter = new Operation();
            ChangePassword = new Operation();
            Sort = new Operation();
            Etag = new Operation();
        }

        /// <summary>
        /// An HTTP-addressable URL pointing to the service provider's
        /// human-consumable help documentation.OPTIONAL.
        /// </summary>
        [JsonProperty("documentationUri")]
        public string DocumentationUri { get; set; }

        /// <summary>
        /// The service provider's server unique id. attribute.OPTIONAL.
        /// </summary>
        [JsonProperty("id")]
        new public string Id { get; set; }

        /// <summary>
        /// A complex type that specifies PATCH configuration options.
        /// REQUIRED.See Section 3.5.2 of[RFC7644].
        /// </summary>
        [JsonRequired]
        [JsonProperty("patch")]
        public Operation Patch { get; set; }

        /// <summary>
        /// A complex type that specifies bulk configuration options.  See
        /// Section 3.7 of[RFC7644].  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("bulk")]
        public Operation Bulk { get; set; }

        /// <summary>
        /// A complex type that specifies FILTER options.  REQUIRED.  See
        /// Section 3.4.2.2 of[RFC7644].
        /// </summary>
        [JsonRequired]
        [JsonProperty("filter")]
        public Operation Filter { get; set; }

        /// <summary>
        /// A complex type that specifies configuration options related to
        /// changing a password.REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("changePassword")]
        public Operation ChangePassword { get; set; }

        /// <summary>
        /// A complex type that specifies Sort configuration options.
        /// REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("sort")]
        public Operation Sort { get; set; }

        /// <summary>
        /// A complex type that specifies ETag configuration options.
        /// REQUIRED
        /// </summary>
        [JsonRequired]
        [JsonProperty("etag")]
        public Operation Etag { get; set; }

        /// <summary>
        /// A multi-valued complex type that specifies supported
        /// authentication scheme properties.To enable seamless discovery of
        /// configurations, the service provider SHOULD, with the appropriate
        /// security considerations, make the authenticationSchemes attribute
        /// publicly accessible without prior authentication.REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("authenticationSchemes")]
        public List<AuthenticationScheme> AuthenticationSchemes { get; set; }

        public static ServiceProvider Create()
        {
            return new ServiceProvider
            {
                Schemas = new List<string> { "urn:ietf:params:scim:schemas:core:2.0:ServiceProviderConfig" }
            };
        }
    }
}
