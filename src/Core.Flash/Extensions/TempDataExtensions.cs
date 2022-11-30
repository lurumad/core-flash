using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace Core.Flash.Extensions
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value)
        {
            tempData[key] = JsonSerializer.Serialize(value);
        } 

        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            return tempData.TryGetValue(key, out var value) ? JsonSerializer.Deserialize<T>(value.ToString()) : default;
        }
    }
}
