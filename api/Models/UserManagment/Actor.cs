using System.Text.Json.Serialization;

namespace api.Models.UserManagment
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Actor
    {
        Employee,
        Student,
        Guardian,
        Administrator,
        Manager,
        Guest
    }
}
