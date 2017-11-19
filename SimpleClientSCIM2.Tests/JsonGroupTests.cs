using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleClientSCIM2.Schema;
using System.IO;
using Newtonsoft.Json;

namespace SimpleClientSCIM2.Tests
{
    [TestClass]
    public class JsonGroupTests
    {
        [TestMethod]
        public void TestGroupJson()
        {
            var jsonText = File.ReadAllText("group.json");
            Group group = JsonConvert.DeserializeObject<Group>(jsonText);
            TestGroup(group);

            jsonText = JsonConvert.SerializeObject(group);
            Group nGroup = JsonConvert.DeserializeObject<Group>(jsonText);
            TestGroup(nGroup);
        }

        public void TestGroup(Group group)
        {
            Assert.IsNotNull(group);

            Assert.IsNotNull(group.Schemas);
            Assert.AreEqual(1, group.Schemas.Count);
            Assert.AreEqual("urn:ietf:params:scim:schemas:core:2.0:Group", group.Schemas[0]);

            Assert.AreEqual("e9e30dba-f08f-4109-8486-d5c6a331660a", group.Id);
            Assert.AreEqual("Tour Guides", group.DisplayName);

            var m = group.Members;
            Assert.IsNotNull(m);
            Assert.AreEqual(2, m.Count);
            Assert.AreEqual("2819c223-7f76-453a-919d-413861904646", m[0].Value);
            Assert.AreEqual("https://example.com/v2/Users/2819c223-7f76-453a-919d-413861904646", m[0].Ref);
            Assert.AreEqual("Babs Jensen", m[0].Display);
            Assert.AreEqual("902c246b-6245-4190-8e05-00816be7344a", m[1].Value);
            Assert.AreEqual("https://example.com/v2/Users/902c246b-6245-4190-8e05-00816be7344a", m[1].Ref);
            Assert.AreEqual("Mandy Pepperidge", m[1].Display);

            var meta = group.MetaInfo;
            Assert.IsNotNull(meta);
            Assert.AreEqual("Group", meta.ResourceType);
            Assert.AreEqual("2010-01-23T04:56:22Z", meta.Created.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("2011-05-13T04:42:34Z", meta.LastModified.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("W/\"3694e05e9dff592\"", meta.Version);
            Assert.AreEqual("https://example.com/v2/Groups/e9e30dba-f08f-4109-8486-d5c6a331660a", meta.Location);
        }
    }
}
