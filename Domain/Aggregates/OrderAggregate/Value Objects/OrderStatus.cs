using System.Text.Json.Serialization;

namespace Domain.Aggregates.OrderAggregate.Value_Objects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Completed,
        Cancelled
    }
}

