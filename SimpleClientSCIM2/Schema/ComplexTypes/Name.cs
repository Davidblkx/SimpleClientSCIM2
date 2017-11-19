using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    /// <summary>
    /// The components of the user's name.
    /// </summary>
    public class Name
    {
        public Name() { }
        public Name(string firstName, string lastName)
        {
            GivenName = firstName;
            FamilyName = lastName;
        }

        /// <summary>
        /// The full name, including all middle names, titles, and
        /// suffixes as appropriate, formatted for display(e.g.,
        /// "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// The family name of the User, or last name in most
        /// Western languages(e.g., "Jensen" given the full name
        /// "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("familyName")]
        public string FamilyName { get; set; }

        /// <summary>
        /// The given name of the User, or first name in most
        /// Western languages(e.g., "Barbara" given the full name
        /// "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        /// <summary>
        /// The middle name(s) of the User (e.g., "Jane" given the
        /// full name "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The honorific prefix(es) of the User, or title in
        /// most Western languages(e.g., "Ms." given the full name
        /// "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("honorificPrefix")]
        public string HonorificPrefix { get; set; }

        /// <summary>
        /// The honorific suffix(es) of the User, or suffix
        /// in most Western languages(e.g., "III" given the full name
        /// "Ms. Barbara Jane Jensen, III").
        /// </summary>
        [JsonProperty("honorificSuffix")]
        public string HonorificSuffix { get; set; }
    }
}
