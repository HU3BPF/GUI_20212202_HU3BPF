

using Newtonsoft.Json.Serialization;
using System;
using System.Windows;

namespace FarFromFreedom.Model.Helpers
{
    public class JsonRectConverter : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            // Add additional types here such as Vector2/3 etc.
            if (objectType == typeof(Rect))
            {
                return CreateObjectContract(objectType);
            }
            else if(objectType == typeof(Vector))
            {
                return CreateObjectContract(objectType);
            }

            return base.CreateContract(objectType);
        }
    }
}
