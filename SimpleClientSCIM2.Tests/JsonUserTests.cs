using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpleClientSCIM2.Schema;
using System.IO;
using System.Linq;

namespace SimpleClientSCIM2.Tests
{
    [TestClass]
    public class JsonUserTests
    {
        [TestMethod]
        public void TestUserWrite()
        {
            string jsonText = File.ReadAllText("basicUser.json");
            User user = JsonConvert.DeserializeObject<User>(jsonText);
            TestBasicUser(user);

            jsonText = JsonConvert.SerializeObject(user);
            User nUser = JsonConvert.DeserializeObject<User>(jsonText);
            TestBasicUser(nUser);
        }

        [TestMethod]
        public void TestEnterpriseUserWrite()
        {
            string jsonText = File.ReadAllText("enterprise.json");
            EnterpriseUser user = JsonConvert.DeserializeObject<EnterpriseUser>(jsonText);
            TestBasicUser(user);
            TestEnterpriseUser(user);

            jsonText = JsonConvert.SerializeObject(user);
            EnterpriseUser nUser = JsonConvert.DeserializeObject<EnterpriseUser>(jsonText);

            TestBasicUser(nUser);
            TestEnterpriseUser(nUser);
        }

        public void TestBasicUser(User user)
        {
            Assert.IsNotNull(user);

            Assert.IsNotNull(user.Schemas);
            Assert.AreEqual(1, user.Schemas.Count(x => x == "urn:ietf:params:scim:schemas:core:2.0:User"));

            Assert.AreEqual("2819c223-7f76-453a-919d-413861904646", user.Id);
            Assert.AreEqual("701984", user.ExternalId);
            Assert.AreEqual("bjensen@example.com", user.UserName);

            var name = user.Name;
            Assert.IsNotNull(name);
            Assert.AreEqual("Ms. Barbara J Jensen, III", name.Formatted);
            Assert.AreEqual("Jensen", name.FamilyName);
            Assert.AreEqual("Barbara", name.GivenName);
            Assert.AreEqual("Jane", name.MiddleName);
            Assert.AreEqual("Ms.", name.HonorificPrefix);
            Assert.AreEqual("III", name.HonorificSuffix);

            Assert.AreEqual("Babs Jensen", user.DisplayName);
            Assert.AreEqual("Babs", user.NickName);
            Assert.AreEqual("https://login.example.com/bjensen", user.ProfileUrl);

            var emails = user.Emails;
            Assert.IsNotNull(emails);
            Assert.AreEqual(2, emails.Count);
            var e1 = emails[0];
            Assert.IsNotNull(e1);
            Assert.AreEqual("bjensen@example.com", e1.Value);
            Assert.AreEqual("work", e1.Type);
            Assert.IsTrue(e1.Primary);
            var e2 = emails[1];
            Assert.IsNotNull(e2);
            Assert.AreEqual("babs@jensen.org", e2.Value);
            Assert.AreEqual("home", e2.Type);
            Assert.IsFalse(e2.Primary);

            var addresses = user.Addresses;
            Assert.IsNotNull(addresses);
            Assert.AreEqual(2, addresses.Count);
            var a1 = addresses[0];
            Assert.IsNotNull(a1);
            Assert.AreEqual("work", a1.Type);
            Assert.AreEqual("100 Universal City Plaza", a1.StreetAddress);
            Assert.AreEqual("Hollywood", a1.Locality);
            Assert.AreEqual("CA", a1.Region);
            Assert.AreEqual("91608", a1.PostalCode);
            Assert.AreEqual("USA", a1.Country);
            Assert.AreEqual("100 Universal City Plaza\nHollywood, CA 91608 USA", a1.Formatted);
            Assert.IsTrue(a1.Primary);
            var a2 = addresses[1];
            Assert.IsNotNull(a2);
            Assert.AreEqual("home", a2.Type);
            Assert.AreEqual("456 Hollywood Blvd", a2.StreetAddress);
            Assert.AreEqual("Hollywood", a2.Locality);
            Assert.AreEqual("CA", a2.Region);
            Assert.AreEqual("91608", a2.PostalCode);
            Assert.AreEqual("USA", a2.Country);
            Assert.AreEqual("456 Hollywood Blvd\nHollywood, CA 91608 USA", a2.Formatted);
            Assert.IsFalse(a2.Primary);

            var phones = user.PhoneNumbers;
            Assert.IsNotNull(phones);
            Assert.AreEqual(2, phones.Count);
            Assert.IsNotNull(phones[0]);
            Assert.AreEqual("555-555-5555", phones[0].Value);
            Assert.AreEqual("work", phones[0].Type);
            Assert.IsNotNull(phones[1]);
            Assert.AreEqual("555-555-4444", phones[1].Value);
            Assert.AreEqual("mobile", phones[1].Type);

            var ims = user.IMS;
            Assert.IsNotNull(ims);
            Assert.AreEqual(1, ims.Count);
            Assert.IsNotNull(ims[0]);
            Assert.AreEqual("someaimhandle", ims[0].Value);
            Assert.AreEqual("aim", ims[0].Type);

            var photos = user.Photos;
            Assert.IsNotNull(photos);
            Assert.AreEqual(2, photos.Count);
            Assert.IsNotNull(photos[0]);
            Assert.AreEqual("https://photos.example.com/profilephoto/72930000000Ccne/F", photos[0].Value);
            Assert.AreEqual("photo", photos[0].Type);
            Assert.IsNotNull(photos[1]);
            Assert.AreEqual("https://photos.example.com/profilephoto/72930000000Ccne/T", photos[1].Value);
            Assert.AreEqual("thumbnail", photos[1].Type);

            Assert.AreEqual("Employee", user.UserType);
            Assert.AreEqual("Tour Guide", user.Title);
            Assert.AreEqual("en-US", user.PreferredLanguage);
            Assert.AreEqual("America/Los_Angeles", user.Timezone);
            Assert.IsTrue(user.Active);
            Assert.AreEqual("t1meMa$heen", user.Password);

            var groups = user.Groups;
            Assert.IsNotNull(groups);
            Assert.AreEqual(3, groups.Count);
            Assert.IsNotNull(groups[0]);
            Assert.AreEqual("e9e30dba-f08f-4109-8486-d5c6a331660a", groups[0].Value);
            Assert.AreEqual("https://example.com/v2/Groups/e9e30dba-f08f-4109-8486-d5c6a331660a", groups[0].Ref);
            Assert.AreEqual("Tour Guides", groups[0].Display);
            Assert.IsNotNull(groups[1]);
            Assert.AreEqual("fc348aa8-3835-40eb-a20b-c726e15c55b5", groups[1].Value);
            Assert.AreEqual("https://example.com/v2/Groups/fc348aa8-3835-40eb-a20b-c726e15c55b5", groups[1].Ref);
            Assert.AreEqual("Employees", groups[1].Display);
            Assert.IsNotNull(groups[2]);
            Assert.AreEqual("71ddacd2-a8e7-49b8-a5db-ae50d0a5bfd7", groups[2].Value);
            Assert.AreEqual("https://example.com/v2/Groups/71ddacd2-a8e7-49b8-a5db-ae50d0a5bfd7", groups[2].Ref);
            Assert.AreEqual("US Employees", groups[2].Display);

            const string cert = "MIIDQzCCAqygAwIBAgICEAAwDQYJKoZIhvcN" +
                "AQEFBQAwTjELMAkGA1UEBhMCVVMxEzARBgNVBAgMCkNhbGlmb3Ju" +
                "aWExFDASBgNVBAoMC2V4YW1wbGUuY29tMRQwEgYDVQQDDAtleGFt" +
                "cGxlLmNvbTAeFw0xMTEwMjIwNjI0MzFaFw0xMjEwMDQwNjI0MzFa" +
                "MH8xCzAJBgNVBAYTAlVTMRMwEQYDVQQIDApDYWxpZm9ybmlhMRQw" +
                "EgYDVQQKDAtleGFtcGxlLmNvbTEhMB8GA1UEAwwYTXMuIEJhcmJh" +
                "cmEgSiBKZW5zZW4gSUlJMSIwIAYJKoZIhvcNAQkBFhNiamVuc2Vu" +
                "QGV4YW1wbGUuY29tMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIB" +
                "CgKCAQEA7Kr+Dcds/JQ5GwejJFcBIP682X3xpjis56AK02bc1FLg" +
                "zdLI8auoR+cC9/Vrh5t66HkQIOdA4unHh0AaZ4xL5PhVbXIPMB5v" +
                "APKpzz5iPSi8xO8SL7I7SDhcBVJhqVqr3HgllEG6UClDdHO7nkLu" +
                "wXq8HcISKkbT5WFTVfFZzidPl8HZ7DhXkZIRtJwBweq4bvm3hM1O" +
                "s7UQH05ZS6cVDgweKNwdLLrT51ikSQG3DYrl+ft781UQRIqxgwqC" +
                "fXEuDiinPh0kkvIi5jivVu1Z9QiwlYEdRbLJ4zJQBmDrSGTMYn4l" +
                "Rc2HgHO4DqB/bnMVorHB0CC6AV1QoFK4GPe1LwIDAQABo3sweTAJ" +
                "BgNVHRMEAjAAMCwGCWCGSAGG+EIBDQQfFh1PcGVuU1NMIEdlbmVy" +
                "YXRlZCBDZXJ0aWZpY2F0ZTAdBgNVHQ4EFgQU8pD0U0vsZIsaA16l" +
                "L8En8bx0F/gwHwYDVR0jBBgwFoAUdGeKitcaF7gnzsNwDx708kqa" +
                "Vt0wDQYJKoZIhvcNAQEFBQADgYEAA81SsFnOdYJtNg5Tcq+/ByED" +
                "rBgnusx0jloUhByPMEVkoMZ3J7j1ZgI8rAbOkNngX8+pKfTiDz1R" +
                "C4+dx8oU6Za+4NJXUjlL5CvV6BEYb1+QAEJwitTVvxB/A67g42/v" +
                "zgAtoRUeDov1+GFiBZ+GNF/cAYKcMtGcrs2i97ZkJMo=";
            Assert.AreEqual(cert, user.Certificates[0].Value);

            var meta = user.MetaInfo;
            Assert.IsNotNull(meta);
            Assert.AreEqual("User", meta.ResourceType);
            Assert.AreEqual("2010-01-23T04:56:22Z", meta.Created.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("2011-05-13T04:42:34Z", meta.LastModified.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual("W/\"a330bc54f0671c9\"", meta.Version);
            Assert.AreEqual("https://example.com/v2/Users/2819c223-7f76-453a-919d-413861904646", meta.Location);
        }

        public void TestEnterpriseUser(EnterpriseUser user)
        {
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.Schemas);
            Assert.AreEqual(1, user.Schemas.Count(x => x == "urn:ietf:params:scim:schemas:extension:enterprise:2.0:User"));

            var info = user.EnterpriseInfo;
            Assert.IsNotNull(info);
            Assert.AreEqual("701984", info.EmployeeNumber);
            Assert.AreEqual("4130", info.CostCenter);
            Assert.AreEqual("Universal Studios", info.Organization);
            Assert.AreEqual("Theme Park", info.Division);
            Assert.AreEqual("Tour Operations", info.Department);

            var manager = info.Manager;
            Assert.IsNotNull(manager);
            Assert.AreEqual("../Users/26118915-6090-4610-87e4-49d8ca9f808d", manager.Ref);
            Assert.AreEqual("John Smith", manager.DisplayName);
            Assert.AreEqual("26118915-6090-4610-87e4-49d8ca9f808d", manager.Value);
        }
    }
}
