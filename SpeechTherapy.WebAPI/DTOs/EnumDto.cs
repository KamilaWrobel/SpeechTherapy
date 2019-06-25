using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeechTherapy.WebAPI.DTOs
{
    public class EnumValueDto
    {
        public EnumValueDto(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class EnumDto
    {
        public EnumDto(Dictionary<string, string> enums)
        {
            Enums = new List<EnumValueDto>();
            foreach (var item in enums)
            {
                Enums.Add(new EnumValueDto(item.Key, item.Value));
            }
        }

        public List<EnumValueDto> Enums { get; set; }
    }
}