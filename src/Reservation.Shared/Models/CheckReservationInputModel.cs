using System.Text.Json.Serialization;

namespace Reservation.Shared.Models
{
    public class CheckReservationInputModel
    {
        [JsonPropertyName("Tren")]
        public TrainModel Train { get; set; }

        [JsonPropertyName("RezervasyonYapilacakKisiSayisi")]
        public int CustomerCount { get; set; }

        [JsonPropertyName("KisilerFarkliVagonlaraYerlestirilebilir")]
        public bool DifferentWagonControl { get; set; }
    }
}
