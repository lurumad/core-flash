using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Core.Flash.Extensions
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value)
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        } 

        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            return tempData.TryGetValue(key, out object value) ? JsonConvert.DeserializeObject<T>(value.ToString()) : default(T);
        }
    }
}
