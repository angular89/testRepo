using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Qualification
    {
        Bachelor,
        Master,
        Doctorate,
        Other
    }
}
