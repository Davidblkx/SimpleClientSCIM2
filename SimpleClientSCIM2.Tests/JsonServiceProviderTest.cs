using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpleClientSCIM2.Schema;
using System.IO;
using System;

namespace SimpleClientSCIM2.Tests
{
    [TestClass]
    public class JsonServiceProviderTest
    {
        [TestMethod]
        public void TestJsonService()
        {
            var jsonText = File.ReadAllText("service.json");
            ServiceProvider sp = JsonConvert.DeserializeObject<ServiceProvider>(jsonText);
            TestServiceProvider(sp);

            jsonText = JsonConvert.SerializeObject(sp);
            ServiceProvider nSp = JsonConvert.DeserializeObject<ServiceProvider>(jsonText);
            TestServiceProvider(nSp);
        }

        private void TestServiceProvider(ServiceProvider sp)
        {
            Assert.IsNotNull(sp);
            Assert.AreEqual(1, sp.Schemas.Count);
            Assert.AreEqual("urn:ietf:params:scim:schemas:core:2.0:ServiceProviderConfig", sp.Schemas[0]);
            Assert.AreEqual("http://example.com/help/scim.html", sp.DocumentationUri);

            Assert.IsNotNull(sp.Patch);
            Assert.IsTrue(sp.Patch.Supported);
            Assert.IsNotNull(sp.Bulk);
            Assert.IsTrue(sp.Bulk.Supported);
            Assert.IsNotNull(sp.Filter);
            Assert.IsTrue(sp.Filter.Supported);
            Assert.IsNotNull(sp.ChangePassword);
            Assert.IsTrue(sp.ChangePassword.Supported);
            Assert.IsNotNull(sp.Sort);
            Assert.IsTrue(sp.Sort.Supported);
            Assert.IsNotNull(sp.Etag);
            Assert.IsTrue(sp.Etag.Supported);

            var auth = sp.AuthenticationSchemes;
            Assert.IsNotNull(auth);
            Assert.AreEqual(2, auth.Count);
            Assert.AreEqual("OAuth Bearer Token", auth[0].Name);
            Assert.AreEqual("Authentication scheme using the OAuth Bearer Token Standard", auth[0].Description);
            Assert.AreEqual("http://www.rfc-editor.org/info/rfc6750", auth[0].SpecUri);
            Assert.AreEqual("http://example.com/help/oauth.html", auth[0].DocumentationUri);
            Assert.AreEqual("oauthbearertoken", auth[0].Type);
            Assert.IsTrue(auth[0].Primary);
            Assert.AreEqual("HTTP Basic", auth[1].Name);
            Assert.AreEqual("Authentication scheme using the HTTP Basic Standard", auth[1].Description);
            Assert.AreEqual("http://www.rfc-editor.org/info/rfc2617", auth[1].SpecUri);
            Assert.AreEqual("http://example.com/help/httpBasic.html", auth[1].DocumentationUri);
            Assert.AreEqual("httpbasic", auth[1].Type);
            Assert.IsFalse(auth[1].Primary);

            var meta = sp.MetaInfo;
            Assert.IsNotNull(meta);
            Assert.AreEqual("ServiceProviderConfig", meta.ResourceType);
            Assert.AreEqual("2010-01-23T04:56:22Z", meta.Created.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("2011-05-13T04:42:34Z", meta.LastModified.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("W/\"3694e05e9dff594\"", meta.Version);
            Assert.AreEqual("https://example.com/v2/ServiceProviderConfig", meta.Location);
        }
    }
}
