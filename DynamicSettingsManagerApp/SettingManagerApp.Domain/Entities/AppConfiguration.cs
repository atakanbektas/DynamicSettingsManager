using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingManagerApp.Domain.Entities
{
    public class AppConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Value { get; set; } = null!; 
        public bool IsActive { get; set; }
        public string ApplicationName { get; set; } = null!;

        // Type alanına göre değeri doğru tipe dönüştüren metod
        public dynamic GetTypedValue()
        {
            switch (Type.ToLower())
            {
                case "int":
                    if (int.TryParse(Value, out int intValue))
                        return intValue;
                    throw new InvalidCastException($"Value '{Value}' cannot be cast to type int.");

                case "bool":
                    if (bool.TryParse(Value, out bool boolValue))
                        return boolValue;
                    throw new InvalidCastException($"Value '{Value}' cannot be cast to type bool.");

                case "double":
                    if (double.TryParse(Value, out double doubleValue))
                        return doubleValue;
                    throw new InvalidCastException($"Value '{Value}' cannot be cast to type double.");

                case "string":
                    return Value;

                default:
                    throw new InvalidOperationException($"Unsupported type '{Type}'");
            }
        }
    }

}
