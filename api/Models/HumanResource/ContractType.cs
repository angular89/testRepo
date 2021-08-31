using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContractType
    {
        Permanent,
        FixedTerm,
        Temporary,
        Casual
    }
}
