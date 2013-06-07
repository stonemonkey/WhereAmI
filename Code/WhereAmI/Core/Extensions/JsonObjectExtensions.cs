using Windows.Data.Json;

namespace WhereAmI.Core.Extensions
{
    public static class JsonObjectExtensions
    {
        /// <summary>
        /// Get a value of an item from a <see cref="JsonObject"/> as a string.
        /// When the item cannot be found, the null value is retuned.
        /// </summary>
        public static string GetValue(this JsonObject obj, string key)
        {
            return obj.ContainsKey(key)
                       ? obj[key].GetString()
                       : null;
        }
    }
}
