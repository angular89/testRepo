using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DeductionType
    {
        Absence,
        Penalty,
        Loans,
        Overpaid,
        Deposit,
        Subscriptions,
        Services,
        Deficit
    }
}
