using Newtonsoft.Json;

namespace SimpleClientSCIM2.Schema.ComplexTypes
{
    public class Operation
    {
        /// <summary>
        /// A Boolean value specifying whether or not the operation
        /// is supported.REQUIRED.
        /// </summary>
        [JsonRequired]
        [JsonProperty("supported")]
        public bool Supported { get; set; }
    }
}
