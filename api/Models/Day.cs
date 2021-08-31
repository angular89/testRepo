using System.Text.Json.Serialization;

namespace api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Day
    {
        Saturday = 1,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}
