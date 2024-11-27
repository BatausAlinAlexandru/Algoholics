using System.Text.Json.Serialization;

namespace Domain.Aggregates.UserAggregate.Value_Objects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserAccountRole
    {
        User,
        Admin,
        Moderator
    }
}
