using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace EducationPortal.Helpers
{
    //helper to ignore some properties from serialization
    public class JsonResolver : DefaultContractResolver
    {
        private HashSet<string> _propsToIgnore;

        public JsonResolver(IEnumerable<string> propNamesToIgnore)
        {
            _propsToIgnore = new HashSet<string>(propNamesToIgnore);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (_propsToIgnore.Contains(property.PropertyName))
            {
                property.ShouldSerialize = (x) => { return false; };
            }

            return property;
        }
    }

}
