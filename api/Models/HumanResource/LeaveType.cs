using System.Text.Json.Serialization;

namespace api.Models.HumanResource
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LeaveType
    {
        Short_Vacation,
        Annual_Vacation,
        Medical_TimeOff,
        Sick_Days,
        Disability,
        Family_TimeOff,
        Bereavement,
        Parental_Vacation,
        Emergency_Childcare,
        Community_Service
    }
}
