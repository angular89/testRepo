using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RequestType
    {
        Enquiry,
        Meeting,
        Grievance,
        Loan
    }
}
