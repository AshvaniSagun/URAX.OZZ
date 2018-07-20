using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UraxBpcPno34Api.Models
{
    public static class ObjectToDictionaryHelper
    {
        public static IDictionary<string, string> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        public static IDictionary<string, string> ToDictionary<T>(this object source)
        {
            var error = string.Empty;
            if (source == null)
                return null;

            var dictionary = new Dictionary<string, string>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                AddPropertyToDictionary<T>(property, source, dictionary);

            }

            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, Dictionary<string, string> dictionary)
        {
            if (property.GetValue(source) != null)
            {
                string value = property.GetValue(source).ToString();
                if (IsOfType<string>(value))
                    dictionary.Add(property.Name.ToUpper(), value);
            }
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }


    }
}
