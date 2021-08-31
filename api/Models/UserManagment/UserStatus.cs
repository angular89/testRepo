using System.Text.Json.Serialization;

namespace api.Models.UserManagment
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserStatus
    {
        Inactive,
        Active,
        Blocked
    }
}
