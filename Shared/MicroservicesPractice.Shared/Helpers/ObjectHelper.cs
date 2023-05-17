using System;

namespace MicroservicesPractice.Shared.Helpers
{
    public static class ObjectHelper
    {
        public static void ObjectNullCheck(object value, string nameOfValue)
        {
            if (value == null) throw new InvalidOperationException($"{nameOfValue} is null."); 
        }
    }
}
