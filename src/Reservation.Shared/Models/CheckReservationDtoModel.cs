using System.Text.Json.Serialization;

namespace Reservation.Shared.Models
{
    public class CheckReservationDtoModel
    {
        [JsonPropertyName("VagonAdi")]
        public string WagonTitle { get; set; }

        [JsonPropertyName("KisiSayisi")]
        public int CustomerCount { get; set; }
    }
}
