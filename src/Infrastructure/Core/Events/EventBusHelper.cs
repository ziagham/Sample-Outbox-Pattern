using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Core.Commands;

namespace Infrastructure.Core.Events
{
    public static class EventBusHelper
    {
        public static string GetTypeName(Type type)
        {
            var name = type.FullName.ToLower().Replace("+", ".");

            if (type is IEvent)
            {
                name += "_event";
            }
            else if (type is ICommand)
            {
                name += "_command";
            }

            return name;
        }

        public static string GetTypeName<T>()
        {
            return GetTypeName(typeof(T));
        }
    }
}
