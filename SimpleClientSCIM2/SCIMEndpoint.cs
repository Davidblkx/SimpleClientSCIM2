using System;
using System.Collections.Generic;
using SimpleClientSCIM2.Schema;
using System.Linq;

namespace SimpleClientSCIM2
{
    public class SCIMEndpoint
    {
        public string Users { get; set; }
        public List<Type> UsersType { get; }

        public string Groups { get; set; }
        public List<Type> GroupsType { get; }

        public string Me { get; set; }
        public List<Type> MeType { get; }

        public string ServiceProvider { get; set; }
        public List<Type> ServiceProviderType { get; }

        public string ResourceTypes { get; set; }
        public List<Type> ResourceTypesType { get; }

        public string Schemas { get; set; }
        public List<Type> SchemasType { get; }

        public SCIMEndpoint()
        {
            Users = "/Users";
            Groups = "/Groups";
            ServiceProvider = "/ServiceProviderConfig";
            ResourceTypes = "/ResourceTypes";
            Schemas = "/Schemas";

            UsersType = new List<Type>
            {
                typeof(User),
                typeof(EnterpriseUser)
            };
            GroupsType = new List<Type> { typeof(Group) };
            ServiceProviderType = new List<Type> { typeof(ServiceProvider) };
            ResourceTypesType = new List<Type> { typeof(ResourceType) };
            SchemasType = new List<Type> { typeof(SchemaDefinition) };
        }

        private bool MatchType(List<Type> list, Type t)
        {
            return list.Count(x => x.IsAssignableFrom(t)) > 0;
        }

        public string GetEndpoint<T>() where T : Resource
        {
            var t = typeof(T);

            if (MatchType(UsersType, t)) return Users;
            if (MatchType(GroupsType, t)) return Groups;
            if (MatchType(ServiceProviderType, t)) return ServiceProvider;
            if (MatchType(ResourceTypesType, t)) return ResourceTypes;
            if (MatchType(SchemasType, t)) return Schemas;

            throw new Exception("Type endpoint not found");
        }
    }
}
