using SimpleClientSCIM2.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Newtonsoft.Json;
using System;

namespace SimpleClientSCIM2.Tests
{
    [TestClass]
    public class JsonResourceType
    {
        [TestMethod]
        public void TestJsonResourceType()
        {
            var jsonText = File.ReadAllText("resourceType.json");
            ResourceType rt = JsonConvert.DeserializeObject<ResourceType>(jsonText);
            TestJsonResourceType(rt);

            jsonText = JsonConvert.SerializeObject(rt);
            var nRt = JsonConvert.DeserializeObject<ResourceType>(jsonText);
            TestJsonResourceType(nRt);
        }

        private void TestJsonResourceType(ResourceType rt)
        {
            Assert.IsNotNull(rt);
            Assert.AreEqual(1, rt.Schemas.Count);
            Assert.AreEqual("urn:ietf:params:scim:schemas:core:2.0:ResourceType", rt.Schemas[0]);
            Assert.AreEqual("User", rt.Id);
            Assert.AreEqual("User", rt.Name);
            Assert.AreEqual("/Users", rt.Endpoint);
            Assert.AreEqual("urn:ietf:params:scim:schemas:core:2.0:User", rt.Schema);

            Assert.IsNotNull(rt.SchemaExtensions);
            Assert.AreEqual(1, rt.SchemaExtensions.Count);
            Assert.AreEqual("urn:ietf:params:scim:schemas:extension:enterprise:2.0:User", rt.SchemaExtensions[0].Schema);
            Assert.IsTrue(rt.SchemaExtensions[0].Required);

            Assert.IsNotNull(rt.MetaInfo);
            Assert.AreEqual("https://example.com/v2/ResourceTypes/User", rt.MetaInfo.Location);
            Assert.AreEqual("ResourceType", rt.MetaInfo.ResourceType);
        }
    }
}
