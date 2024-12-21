using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: CLSCompliant(true)]

namespace JsonSerialization;

public static class JsonSerializationOperations
{
    public static string SerializeObjectToJson(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static T? DeserializeJsonToObject<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }

    public static string SerializeCompanyObjectToJson(object obj)
    {
        // Serialize the Company object to JSON with custom settings
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = false,

            // Optional: Formats the JSON for better readability
        });
    }

    public static T? DeserializeCompanyJsonToObject<T>(string json)
    {
        // Deserialize the JSON string to an object of type T
        return JsonSerializer.Deserialize<T>(json);
    }

    public static string SerializeDictionary(Company obj)
    {
        // Ensure obj is not null
        if (obj == null)
        {
            return string.Empty;
        }

        // Ensure Domains property is not null
        if (obj.Domains == null)
        {
            return string.Empty;
        }

        // Create a new dictionary with camel-cased keys and original integer values
        var camelCasedDictionary = new Dictionary<string, int>();

        foreach (var kvp in obj.Domains)
        {
            // Convert each key to camel case
            var camelCasedKey = JsonNamingPolicy.CamelCase.ConvertName(kvp.Key);

            // Add the camel-cased key with the original integer value
            camelCasedDictionary[camelCasedKey] = kvp.Value;
        }

        // Set up serialization options
        var options = new JsonSerializerOptions
        {
            WriteIndented = false, // Optional: formats the JSON output
        };

        // Serialize the dictionary with camel-cased keys and integer values
        return JsonSerializer.Serialize(camelCasedDictionary, options);
    }

    public static string SerializeEnum(Company obj)
    {
        // Set up serialization options with JsonStringEnumConverter
        var options = new JsonSerializerOptions
        {
            WriteIndented = false, // Optional: formats the JSON output
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        };

        // Serialize the Company object with the configured options
        return JsonSerializer.Serialize(obj, options);
    }
}
