using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageGenerator
{
    public class PropertyBuilder
    {
        public string GetProperty(Newtonsoft.Json.Linq.JProperty jToken)
        {
            string propertyName = char.ToUpper(jToken.Name[0]) + jToken.Name.Substring(1);

            if (jToken.Value.Type == Newtonsoft.Json.Linq.JTokenType.Integer)
            {
                return $"   public int {propertyName};";
            }
            return $"   public {jToken.Value.Type} {propertyName};";
        }
    }
}