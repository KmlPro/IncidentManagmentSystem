using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IncidentReport.Infrastructure.Configuration.JsonConvertContractResolvers
{
    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        private readonly HashSet<string> _ignoreProps;
        
        public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
        {
            this._ignoreProps = new HashSet<string>(propNamesToIgnore);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (this._ignoreProps.Contains(property.PropertyName))
            {
                property.ShouldSerialize = _ => false;
            }
            return property;
        }
    }
}
