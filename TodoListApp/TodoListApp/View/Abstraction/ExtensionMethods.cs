using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.View.Abstraction
{
    public static class ExtensionMethods
    {
        public static T ToEnum<T>(this string text, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(text))
            {
                return defaultValue;
            }
            T convertedValue;
            return Enum.TryParse<T>(text, true, out convertedValue) ? convertedValue : defaultValue;
        }
    }
}
