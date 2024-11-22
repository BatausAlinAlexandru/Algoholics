using System.Text.Json.Serialization;

namespace Domain.Aggregates.OrderAggregate.Value_Objects
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PaymentMethod
    {
        Card,
        Cash
    }
}