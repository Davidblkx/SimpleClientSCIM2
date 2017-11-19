using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.Extension;
using System.Collections.Generic;

namespace SimpleClientSCIM2.Schema
{
    /// <summary>
    /// User that implements the schema:
    /// "urn:ietf:params:scim:schemas:extension:enterprise:2.0:User"
    /// </summary>
    public class EnterpriseUser : User
    {
        public EnterpriseUser()
        {
            EnterpriseInfo = new EnterpriseUserExtension();
        }

        [JsonProperty("urn:ietf:params:scim:schemas:extension:enterprise:2.0:User")]
        public EnterpriseUserExtension EnterpriseInfo { get; set; }

        new public static EnterpriseUser Create()
        {
            return new EnterpriseUser
            {
                Schemas = new List<string> {
                    "urn:ietf:params:scim:schemas:core:2.0:User",
                    "urn:ietf:params:scim:schemas:extension:enterprise:2.0:User"
                }
            };
        }
    }
}
