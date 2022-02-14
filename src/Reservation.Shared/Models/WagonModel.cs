using System.Text.Json.Serialization;

namespace Reservation.Shared.Models
{
    public class WagonModel
    {
        [JsonPropertyName("Ad")]
        public string Title { get; set; }

        [JsonPropertyName("Kapasite")]
        public int SeatCapacity { get; set; }

        [JsonPropertyName("DoluKoltukAdet")]
        public int ReservedSeatCount { get; set; }
    }
}
