using Newtonsoft.Json;

namespace Music_app.Domain.Extensions
{
    public static class JsonExtension
    {
        public static string ToJson(this object obj)
        {
            if (obj == null)
                return string.Empty;

            return JsonConvert.SerializeObject(obj);
        }

        public static T? FromJson<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default;

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}