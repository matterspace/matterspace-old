using Matterspace.Model.Attributes;
using Matterspace.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matterspace.Lib.Extensions
{
    public static class EnumExtensions
    {
        public static string GetThreadPage(this Enum enumeration)
        {
            var enumType = enumeration.GetType();

            if (typeof(ThreadType) != enumType)
                throw new InvalidOperationException("The enum must be a ThreadType to get its Thread Page");

            var attribute = enumType
                .GetMember(enumeration.ToString())[0]
                .GetCustomAttributes(typeof(ThreadPageAttribute), false)
                .Cast<ThreadPageAttribute>()
                .FirstOrDefault();

            return attribute.ThreadPageName;
        }
    }
}