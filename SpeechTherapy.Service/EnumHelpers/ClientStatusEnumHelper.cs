using SpeechTherapy.Model.Attributes;
using SpeechTherapy.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechTherapy.Service.EnumHelpers
{
    public static class ClientStatusEnumHelper
    {
        public static Dictionary<string, string> GetClientStatusEnumValues()
        {
            var data = new Dictionary<string, string>();
            var enums = Enum.GetNames(typeof(ClientStatusEnum));
            foreach (var item in enums)
            {
                data.Add(item, GetEnumStringValue(item));
            }

            return data;
        }

        public static string GetEnumStringValue(string enumValue)
        {
            var type = typeof(ClientStatusEnum);
            var memInfo = type.GetMember(enumValue);
            var mem = memInfo.FirstOrDefault(m => m.DeclaringType == type);
            var attributes = mem.GetCustomAttributes(typeof(StringValueAttribute), false);
            var stringValue = ((StringValueAttribute)attributes[0]).StringValue;
            return stringValue;
        }
    }
}
