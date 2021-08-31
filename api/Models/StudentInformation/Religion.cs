using System.Text.Json.Serialization;

namespace api.Models.StudentInformation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Religion
    {
        Islam,
        Other
    }
}
