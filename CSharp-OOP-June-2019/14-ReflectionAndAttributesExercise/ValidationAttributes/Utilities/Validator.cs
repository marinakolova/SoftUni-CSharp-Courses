using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfo = obj
                .GetType()
                .GetProperties();

            foreach (var prop in propertyInfo)
            {
                MyValidationAttribute[] attributes = prop
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attr in attributes)
                {
                    if (!attr.IsValid(prop.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
