using Newtonsoft.Json;
using SimpleClientSCIM2.Schema.ComplexTypes;

namespace SimpleClientSCIM2.Schema.Extension
{
    /// <summary>
    /// The following SCIM extension defines attributes commonly used in
    /// representing users that belong to, or act on behalf of, a business or
    /// enterprise.The enterprise User extension is identified using the
    /// following schema URI:
    /// "urn:ietf:params:scim:schemas:extension:enterprise:2.0:User".
    /// </summary>
    public class EnterpriseUserExtension
    {
        public EnterpriseUserExtension()
        {
            Manager = new Manager();
        }

        /// <summary>
        /// A string identifier, typically numeric or alphanumeric, assigned
        /// to a person, typically based on order of hire or association with
        /// an organization.
        /// </summary>
        [JsonProperty("employeeNumber")]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Identifies the name of a cost center.
        /// </summary>
        [JsonProperty("costCenter")]
        public string CostCenter { get; set; }

        /// <summary>
        /// Identifies the name of an organization.
        /// </summary>
        [JsonProperty("organization")]
        public string Organization { get; set; }

        /// <summary>
        /// Identifies the name of an division.
        /// </summary>
        [JsonProperty("division")]
        public string Division { get; set; }

        /// <summary>
        /// Identifies the name of an department.
        /// </summary>
        [JsonProperty("department")]
        public string Department { get; set; }

        /// <summary>
        /// The user's manager.  A complex type that optionally allows service
        /// providers to represent organizational hierarchy by referencing the
        /// "id" attribute of another User.
        /// </summary>
        [JsonProperty("manager")]
        public Manager Manager { get; set; }
    }
}
