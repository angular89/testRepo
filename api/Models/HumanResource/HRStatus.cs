using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HRStatus
    {
        Inactive,
        Active,
        Quit,
        Leave
    }
}
