using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.ComplexTypes;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema
{
    /// <summary>
    ///  SCIM provides a schema for representing groups, identified using the
    ///  following schema URI: "urn:ietf:params:scim:schemas:core:2.0:Group".
    ///  "Group" resources are meant to enable expression of common
    ///  group-based or role-based access control models, although no explicit
    ///  authorization model is defined.It is intended that the semantics of
    ///  group membership, and any behavior or authorization granted as a
    ///  result of membership, are defined by the service provider; these are
    ///  considered out of scope for this specification.
    /// </summary>
    public class Group : Resource
    {
        public Group()
        {
            Members = new List<MultiValue>();
        }

        /// <summary>
        /// A human-readable name for the Group.  REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// A list of members of the Group.  While values MAY be added or
        /// removed, sub-attributes of members are "immutable".  The "value"
        /// sub-attribute contains the value of an "id" attribute of a SCIM
        /// resource, and the "$ref" sub-attribute must be the URI of a SCIM
        /// resource such as a "User", or a "Group".  The intention of the
        /// "Group" type is to allow the service provider to support nested
        /// groups.Service providers MAY require clients to provide a
        /// non-empty value by setting the "required" attribute characteristic
        /// of a sub-attribute of the "members" attribute in the "Group"
        /// resource schema.
        /// </summary>
        [JsonProperty("members")]
        public List<MultiValue> Members { get; set; }

        public static Group Create()
        {
            return new Group
            {
                Schemas = new List<string> { "urn:ietf:params:scim:schemas:core:2.0:Group" }
            };
        }
    }
}
